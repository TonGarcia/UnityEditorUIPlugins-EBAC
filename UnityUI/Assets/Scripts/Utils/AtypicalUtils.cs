using UnityEngine;
// using UnityEditor; // use it as global, it is better to add modifier to specific methods

public static class AtypicalUtils
{
#if UNITY_EDITOR
    [UnityEditor.MenuItem("Atypical/EditorMenuItem %g")]
    public static void MenuItem()
    {
        Debug.Log("Testing sample Editor MenuItem");
    }    
#endif
}
