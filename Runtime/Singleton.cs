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

        private static T _instance;

        protected virtual void Awake() {
            if (_instance == null) {
                _instance = GetComponent<T>();
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
