using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace MMHFramework
{
    public abstract class ScriptableSingleton<T> : ScriptableObject where T : ScriptableObject
    {
        public static T Instance
        {
            get
            {
                lock(_Lock)
                {
                    if(!_Instance)
                    {
                        _Instance = Resources.Load<T>(typeof(T).Name);
                        if(!_Instance)
                        {
                            _Instance = CreateInstance<T>();
#if UNITY_EDITOR
                            AssetDatabase.CreateAsset(_Instance,"Assets/Resources/" + typeof(T).Name + ".asset");
                            AssetDatabase.SaveAssetIfDirty(_Instance);
#endif
                        }
                    }
                    return _Instance;
                }
            }
        }

        private static T _Instance;

        private static readonly object _Lock;
    }
}