using System.Collections.Generic;
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
    }
}
