using UnityEngine;

namespace MMHFramework
{
    public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance
        {
            get
            {
                lock(_Lock)
                {
                    if(!_Instance)
                    {
                        _Instance = FindObjectOfType<T>();
                        if(!_Instance)
                        {
                            _Instance = new GameObject(typeof(T).Name).AddComponent<T>();
                        }
                    }
                    return _Instance;
                }
            }
        }

        private static T _Instance;

        private static readonly object _Lock;

        protected virtual void Awake()
        {
            if(_Instance && _Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            _Instance = GetComponent<T>();
            DontDestroyOnLoad(gameObject);
        }

        protected virtual void OnDestroy()
        {
            if(_Instance == this)
            {
                _Instance = null;
            }
        }
    }
}