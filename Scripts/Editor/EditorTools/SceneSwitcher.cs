using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using MMHFramework;

namespace MMHFramework.Editor
{
    public class SceneSwitcher : EditorWindow
    {
        private List<string> _ScenePathList = new List<string>();

        private List<string> _RegisteredSceneGUIDList = new List<string>();

        private Vector2 _ScrollPosition;

        public static void OpenWindow()
        {
            GetWindow<SceneSwitcher>("Scene选择");
        }

        private void OnEnable()
        {
            LoadRegisteredSceneGUIDs();
        }

        private void LoadRegisteredSceneGUIDs()
        {
            if(EditorPrefs.HasKey("RegisteredSceneGUIDs"))
            {
                var sceneGUIDs = EditorPrefs.GetString("RegisteredSceneGUIDs").Split(';');
                _RegisteredSceneGUIDList.Clear();
                for(int i = 0; i < sceneGUIDs.Length; i++)
                {
                    _RegisteredSceneGUIDList.Add(sceneGUIDs[i]);
                }
            }
        }

        private void OnGUI()
        {
            var content = UnityEditor.EditorGUIUtility.TrTextContentWithIcon("从所有Scene中选择","UnityLogo");
            if(EditorGUILayout.DropdownButton(content,FocusType.Passive,EditorStyles.toolbarPopup))
            {
                DrawSceneMenus();
            }
            this.DragAndDropObjects(OnDragAndDropObjects);
            DrawRegisteredScenes();
        }

        private void DrawRegisteredScenes()
        {
            _ScrollPosition = EditorGUILayout.BeginScrollView(_ScrollPosition);
            EditorGUILayout.BeginVertical();
            for(int i = 0; i < _RegisteredSceneGUIDList.Count; i++)
            {
                var scenePath = AssetDatabase.GUIDToAssetPath(_RegisteredSceneGUIDList[i]);
                var sceneAsset = AssetDatabase.LoadAssetAtPath<SceneAsset>(scenePath);
                if(sceneAsset == null)
                {
                    _RegisteredSceneGUIDList.RemoveAt(i);
                    i -= 1;
                }
                EditorGUILayout.BeginHorizontal();
                if(GUILayout.Button("X", GUILayout.Width(22f)))
                {
                    _RegisteredSceneGUIDList.RemoveAt(i);
                    i -= 1;
                }
                EditorGUI.BeginDisabledGroup(i <= 0);
                if(GUILayout.Button("▲",GUILayout.Width(22f)))
                {
                    var temp = _RegisteredSceneGUIDList[i];
                    _RegisteredSceneGUIDList[i] = _RegisteredSceneGUIDList[i-1];
                    _RegisteredSceneGUIDList[i - 1] = temp;
                }
                EditorGUI.EndDisabledGroup();
                EditorGUI.BeginDisabledGroup(i >= _RegisteredSceneGUIDList.Count - 1);
                if(GUILayout.Button("▼",GUILayout.Width(22f)))
                {
                    var temp = _RegisteredSceneGUIDList[i];
                    _RegisteredSceneGUIDList[i] = _RegisteredSceneGUIDList[i + 1];
                    _RegisteredSceneGUIDList[i + 1] = temp;
                }
                EditorGUI.EndDisabledGroup();
                var sceneName = Path.GetFileNameWithoutExtension(scenePath);
                if(GUILayout.Button(sceneName))
                {
                    OpenScene(scenePath);
                }
                EditorGUILayout.EndHorizontal();
            }
            EditorGUILayout.EndVertical();
            EditorGUILayout.EndScrollView();
        }

        private void OnDragAndDropObjects(Object[] objects)
        {
            for(int i = 0; i < objects.Length; i++)
            {
                var sceneAsset = objects[i] as SceneAsset;
                if(sceneAsset != null)
                {
                    RegisterScene(sceneAsset);
                }
            }
        }

        private void RegisterScene(SceneAsset sceneAsset)
        {
            var sceneGUID = AssetDatabase.AssetPathToGUID(AssetDatabase.GetAssetPath(sceneAsset));
            if(!_RegisteredSceneGUIDList.Contains(sceneGUID))
            {
                _RegisteredSceneGUIDList.Add(sceneGUID);
            }
        }

        private void DrawSceneMenus()
        {
            string GetRegularPath(string path)
            {
                if(path == null)
                {
                    return null;
                }
                return path.Replace('\\','/');
            }
            var popMenu = new GenericMenu();
            popMenu.allowDuplicateNames = true;
            var sceneGUIDs = AssetDatabase.FindAssets("t:Scene",new string[] { "Assets" });
            _ScenePathList.Clear();
            for(int i = 0; i < sceneGUIDs.Length; i++)
            {
                var scenePath = AssetDatabase.GUIDToAssetPath(sceneGUIDs[i]);
                _ScenePathList.Add(scenePath);
                var directory = Path.GetDirectoryName(scenePath);
                var isInRootDirectory = GetRegularPath("Assets").TrimEnd('/') == GetRegularPath(directory).TrimEnd('/');
                var sceneName = Path.GetFileNameWithoutExtension(scenePath);
                var displayName = sceneName;
                if(!isInRootDirectory)
                {
                    displayName = $"{GetRegularPath(PathUtility.GetRelativePath("Assets",directory))}/{sceneName}";
                }
                popMenu.AddItem(new GUIContent(displayName),false,index =>
                {
                    OpenScene(_ScenePathList[(int)index]);
                },i);
            }
            popMenu.ShowAsContext();
        }

        private void OpenScene(string sceneAssetPath)
        {
            EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
            EditorSceneManager.OpenScene(sceneAssetPath,OpenSceneMode.Single);
        }

        private void OnDisable()
        {
            SaveRegisteredSceneGUIDs();
        }

        private void SaveRegisteredSceneGUIDs()
        {

            EditorPrefs.SetString("RegisteredSceneGUIDs",string.Join(";",_RegisteredSceneGUIDList));
        }
    }
}