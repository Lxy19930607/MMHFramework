using System;
using System.Reflection;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;

namespace MMHFramework.Editor
{
    [InitializeOnLoad]
    public static class ToolbarExtension
    {
        public static readonly List<Action> LeftToolbarGUI = new List<Action>();

        public static readonly List<Action> RightToolbarGUI = new List<Action>();

        private static FieldInfo _OnGuiHandlerField = typeof(IMGUIContainer).GetField("m_OnGUIHandler",BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

        private static ScriptableObject _Toolbar;

        private static GUIStyle _CommandStyle = null;

        static ToolbarExtension()
        {
            EditorApplication.update -= OnUpdate;
            EditorApplication.update += OnUpdate;
        }

        private static void OnUpdate()
        {
            if(!_Toolbar)
            {
                var toolbars = Resources.FindObjectsOfTypeAll(typeof(UnityEditor.Editor).Assembly.GetType("UnityEditor.Toolbar"));
                _Toolbar = toolbars.Length > 0 ? (ScriptableObject)toolbars[0] : null;
                if(_Toolbar)
                {
#if UNITY_2021_1_OR_NEWER
                    var root = _Toolbar.GetType().GetField("m_Root",BindingFlags.NonPublic | BindingFlags.Instance).GetValue(_Toolbar) as VisualElement;
                    RegisterToolbarZoneCallback("ToolbarZoneLeftAlign",OnGUILeft);
                    RegisterToolbarZoneCallback("ToolbarZoneRightAlign",OnGUIRight);
                    void RegisterToolbarZoneCallback(string name,Action callback)
                    {
                        var toolbarZone = root.Q(name);
                        var parent = new VisualElement()
                        {
                            style =
                            {
                                flexGrow =1,
                                flexDirection = FlexDirection.Row
                            }
                        };
                        var container = new IMGUIContainer();
                        container.style.flexGrow = 1;
                        container.onGUIHandler -= callback;
                        container.onGUIHandler += callback;
                        parent.Add(container);
                        toolbarZone.Add(parent);
                    }
#else
                    var windowBackend = typeof(UnityEditor.Editor).Assembly.GetType("UnityEditor.GUIView").GetProperty("windowBackend",BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).GetValue(_Toolbar);
                    var visualTree = (VisualElement)typeof(UnityEditor.Editor).Assembly.GetType("UnityEditor.IWindowBackend").GetProperty("visualTree",BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).GetValue(windowBackend,null);
                    var container = (IMGUIContainer)visualTree[0];
                    container.onGUIHandler -= OnGUI;
                    container.onGUIHandler += OnGUI;
#endif
                    EditorApplication.update -= OnUpdate;
                }
            }
        }

        public static void OnGUI()
        {
            if(_CommandStyle == null)
            {
                _CommandStyle = new GUIStyle("CommandLeft");
            }
            var toolCount = typeof(UnityEditor.Editor).Assembly.GetType("UnityEditor.Toolbar").GetField("k_ToolCount",BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
            var screenWidth = UnityEditor.EditorGUIUtility.currentViewWidth;
            var playButtonsPosition = Mathf.RoundToInt((screenWidth - 140f) * 0.5f);
            var leftRect = new Rect(0,0,screenWidth,Screen.height);
            leftRect.xMin += 32f * (toolCount != null ? ((int)toolCount.GetValue(null)) : 8) + 152f;
            leftRect.xMax = playButtonsPosition - 8f;
            leftRect.y = 5f;
            leftRect.height = 22f;
            var rightRect = new Rect(0,0,screenWidth,Screen.height);
            rightRect.xMin = playButtonsPosition + _CommandStyle.fixedWidth * 3 + 8f;
            rightRect.xMax = screenWidth - 340f;
            rightRect.y = 5f;
            rightRect.height = 22f;
            if(leftRect.width > 0)
            {
                GUILayout.BeginArea(leftRect);
                GUILayout.BeginHorizontal();
                for(int i = 0; i < LeftToolbarGUI.Count; i++)
                {
                    LeftToolbarGUI[i]?.Invoke();
                }
                GUILayout.EndHorizontal();
                GUILayout.EndArea();
            }
            if(rightRect.width > 0)
            {
                GUILayout.BeginArea(rightRect);
                GUILayout.BeginHorizontal();
                for(int i = 0; i < RightToolbarGUI.Count; i++)
                {
                    RightToolbarGUI[i]?.Invoke();
                }
                GUILayout.EndHorizontal();
                GUILayout.EndArea();
            }
        }

        public static void OnGUILeft()
        {
            GUILayout.BeginHorizontal();
            for(int i = 0; i < LeftToolbarGUI.Count; i++)
            {
                LeftToolbarGUI[i]?.Invoke();
            }
            GUILayout.EndHorizontal();
        }

        public static void OnGUIRight()
        {
            GUILayout.BeginHorizontal();
            for(int i = 0; i < RightToolbarGUI.Count; i++)
            {
                RightToolbarGUI[i]?.Invoke();
            }
            GUILayout.EndHorizontal();
        }
    }
}