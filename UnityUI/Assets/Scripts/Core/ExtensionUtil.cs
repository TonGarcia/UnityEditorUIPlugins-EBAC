using UnityEngine;

namespace Core
{
    public static class ExtensionUtil
    {
        public static void Scale(this Transform t, float size = 1.2f)
        {
            t.localScale = Vector3.one * size;
        }
        
        public static void Scale(this GameObject go, float size = 1.2f)
        {
            go.transform.localScale = Vector3.one * size;
        }
    }
}
