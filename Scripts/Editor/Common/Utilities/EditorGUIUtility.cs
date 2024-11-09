using System;
using UnityEngine;
using UnityEditor;

namespace MMHFramework.Editor
{
    public static class EditorGUIUtility
    {
        public static void DragAndDropObjects(this EditorWindow window,Action<UnityEngine.Object[]> handler)
        {
            Event currentEvent = Event.current;
            if(currentEvent.type == EventType.DragUpdated || currentEvent.type == EventType.DragPerform)
            {
                //if(!window.position.Contains(currentEvent.mousePosition))
                //{
                //    return;
                //}
                DragAndDrop.visualMode = DragAndDropVisualMode.Copy;
                if(currentEvent.type == EventType.DragPerform)
                {
                    DragAndDrop.AcceptDrag();
                    UnityEngine.Object[] draggedObjects = DragAndDrop.objectReferences;
                    handler?.Invoke(draggedObjects);
                }
                currentEvent.Use();
            }
        }

        public static void DragAndDropObjects(Rect area,Action<UnityEngine.Object[]> handler)
        {
            Event currentEvent = Event.current;
            if(currentEvent.type == EventType.DragUpdated || currentEvent.type == EventType.DragPerform)
            {
                //if(!area.Contains(currentEvent.mousePosition))
                //{
                //    return;
                //}
                DragAndDrop.visualMode = DragAndDropVisualMode.Copy;
                if(currentEvent.type == EventType.DragPerform)
                {
                    DragAndDrop.AcceptDrag();
                    UnityEngine.Object[] draggedObjects = DragAndDrop.objectReferences;
                    handler?.Invoke(draggedObjects);
                }
                currentEvent.Use();
            }
        }
    }
}