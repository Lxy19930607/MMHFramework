using UnityEngine;
using UnityEditor;

namespace MMHFramework.Editor
{
    [InitializeOnLoad]
    public static class SceneSwitcherToolbarButton
    {
        private static GUIContent _Content;

        static SceneSwitcherToolbarButton()
        {
            _Content = UnityEditor.EditorGUIUtility.TrTextContentWithIcon("Scene","UnityLogo");
            ToolbarExtension.LeftToolbarGUI.Add(OnLeftToolbarGUI);
        }

        private static void OnLeftToolbarGUI()
        {
            GUILayout.FlexibleSpace();
            if(GUILayout.Button(_Content,EditorStyles.toolbarButton))
            {
                SceneSwitcher.OpenWindow();
            }
        }
    }
}