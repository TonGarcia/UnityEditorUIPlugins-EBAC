using Core;
using Models;
using UnityEditor;
using UnityEngine;

namespace Editors
{
    [CustomEditor(typeof(Car))]
    public class CarEditor : Editor
    {
        public static Car TargetObj;
        
        // override the rendered component on the Editor
        public override void OnInspectorGUI()
        {
            Car myTarget = (Car)target;
            
            // Prefab car
            myTarget.carPrefab = (GameObject)EditorGUILayout.ObjectField(myTarget.carPrefab, typeof(GameObject), true);
            Editors.CarEditor.TargetObj = myTarget;
            
            // Gear Speed inputs
            string label1 = "Gear Speed Limit";
            string tooltip1 = "This sets the maximum speed the car can reach in each gear.";
            EditorGUILayout.BeginHorizontal();  // Start horizontal layout
            myTarget.gearSpeedLimit = EditorGUILayout.IntField(new GUIContent(label1), myTarget.gearSpeedLimit);
            GUILayout.Button(new GUIContent("?", tooltip1), GUILayout.Width(20));
            EditorGUILayout.EndHorizontal();  // End horizontal layout

            // Gear Amount inputs
            string label2 = "Maximum Gears";
            string tooltip2 = "This sets the maximum available gears to next max speed level.";
            EditorGUILayout.BeginHorizontal();  // Start horizontal layout
            myTarget.gearAmount = EditorGUILayout.IntField(new GUIContent(label2), myTarget.gearAmount);
            GUILayout.Button(new GUIContent("?", tooltip2), GUILayout.Width(20));
            EditorGUILayout.EndHorizontal();  // End horizontal layout
            
            EditorGUILayout.LabelField("Total max speed", myTarget.TotalSpeed.ToString());
            EditorGUILayout.HelpBox("It calculates the max car speed!", MessageType.Info);

            // Speed checker with Info alert component
            if (myTarget.TotalSpeed >= 100)
            {
                EditorGUILayout.HelpBox("The total speed is greater than the max (100) allowed value!", MessageType.Error);
            }

            // Change next buttons color
            GUI.color = Color.cyan;
            
            // if clicked button it spawns/create a car
            if (GUILayout.Button("Create Car"))
            {
                myTarget.CreateSpawnCar();
            }
            
            // Change next buttons color
            GUI.color = Color.yellow;
            
            // if clicked button it spawns/create a car
            if (GUILayout.Button("Create Car"))
            {
                myTarget.CreateSpawnCar();
            }
        }
    }
}
