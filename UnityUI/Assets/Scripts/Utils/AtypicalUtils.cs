using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

// using UnityEditor; // use it as global, it is better to add modifier to specific methods

public static class AtypicalUtils
{
    
#if UNITY_EDITOR
    [UnityEditor.MenuItem("Atypical/EditorMenuItem %g")]
    public static void MenuItem()
    {
        Debug.Log("Testing sample Editor MenuItem");
    }
    
    [UnityEditor.MenuItem("Atypical/SpawnGameObject %j")]
    public static void SpawnGameObject()
    {
        if (SceneManager.GetActiveScene().IsValid())
        {
            // loads the scene to load the game objects hierarchy
            Scene activeScene = SceneManager.GetActiveScene();
            // loads car editor to load the static var
            GameObject carEditorSample = GameObject.Find("CarEditorSample");
            
            if (carEditorSample != null)
            {
                // Select GameObject to load the preference
                if (Selection.activeObject != carEditorSample)
                {
                    Selection.activeObject = carEditorSample;    
                }
                else
                {
                    Editors.CarEditor.TargetObj.CreateSpawnCar();                    
                }
            }
            else
            {
                Debug.LogError("No GameObject assigned in the Inspector!");
            }
        }
        else
        {
            Debug.LogError("No scene is currently open!");
        }
    }
#endif
}
