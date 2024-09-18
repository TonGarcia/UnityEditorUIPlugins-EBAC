using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Core
{
    public static class ExtensionUtil
    {

        #region Elements Scales & Transforms Helpers
        public static void Scale(this Transform t, float size = 1.2f)
        {
            t.localScale = Vector3.one * size;
        }
        
        public static void Scale(this GameObject go, float size = 1.2f)
        {
            go.transform.localScale = Vector3.one * size;
        }
        #endregion

        #region Collections Helpers
        public static T GetRandom<T>(this List<T> list)
        {
            return list[Random.Range(0, list.Count)];
        }

        public static T GetRandom<T>(this T[] array)
        {
            if (array.Length == 0) return default(T);
            return array[Random.Range(0, array.Length)];
        }
        
        public static T GetRandomButNotSame<T>(this List<T> list, T unique)
        {
            // Base case: If the list has only one item, it's the only choice left.
            if (list.Count == 1) 
                return unique;
    
            int randomIndex = Random.Range(0, list.Count);
            T randomItem = list[randomIndex];
    
            // Recursive call if the random item is the same as 'unique'.
            return (randomItem.Equals(unique)) 
                ? GetRandomButNotSame(list, unique) // Try again recursively
                : randomItem;                         // Return the valid item
        }

        public static T GetRandomButNotSameRecursive<T>(this List<T> list, T unique)
        {
            // Base case: If the list has only one item, it's the only choice left.
            if (list.Count == 1) 
                return unique; 
    
            int randomIndex = Random.Range(0, list.Count);
    
            // Recursive call with the list unchanged if the random item is 'unique'.
            return (list[randomIndex].Equals(unique)) 
                ? GetRandomButNotSameRecursive(list, unique) 
                : list[randomIndex];
        }
        #endregion
        
        #region Editor Helpers
        private static Texture2D _helpIcon;

        [InitializeOnLoadMethod] // Load icon once at Unity editor startup
        private static void Initialize()
        {
            var helpPath = "Assets/Icons/toolbar_help_button.png";
            _helpIcon = AssetDatabase.LoadAssetAtPath<Texture2D>(helpPath);
        }

        public static void ShowTooltip(Rect position, string tooltipText)
        {
            // GUILayout.BeginVertical();
            // GUILayout.FlexibleSpace(); // Push the icon to the top
            GUILayout.Label(new GUIContent(_helpIcon, tooltipText), GUILayout.Width(20), GUILayout.Height(20));
            // GUILayout.FlexibleSpace(); // Push the next element down
            // GUILayout.EndVertical();
            EditorGUILayout.EndHorizontal();
        }
        
        public static void ShowTooltip(string tooltip)
        {
            // You can implement your own tooltip showing mechanism here.
            EditorGUILayout.HelpBox(tooltip, MessageType.Info);
        }
        #endregion
    }
}
