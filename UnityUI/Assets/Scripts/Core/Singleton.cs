using UnityEngine;

namespace Core
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = GetComponent<T>();
                Debug.Log(typeof(T) + " instance initialized.");
            }
            else
            {
                Debug.LogWarning("Duplicate " + typeof(T) + " instance found. Destroying the new one.");
                Destroy(gameObject);
            }
        }
    }
}
