using UnityEngine;

namespace BilliotGames
{
    public class Singleton<T> : MonoBehaviour where T : Component
    {
        public static T Instance
        {
            get
            {
                if (_instance == null) {
                    _instance = FindAnyObjectByType<T>();
                }

                return _instance;
            }
        }

        public bool DontDestroy => dontDestroy;

        private static T _instance;
        [SerializeField] bool dontDestroy=true;

        protected virtual void Awake() {
            if (dontDestroy) {
                DontDestroyOnLoad(gameObject);
                Debug.Log("dont destroy");
            }

            if (_instance == null) {
                _instance = GetComponent<T>();
                Debug.Log("instance assigned");
            }
            else {
                var @this = GetComponent<T>();
                if (_instance.Equals(@this) == false) {
                    Destroy(gameObject);
                }
            }
        }
    }
}
