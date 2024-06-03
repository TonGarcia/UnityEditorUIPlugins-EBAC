using Core;
using Models;
using UnityEditor;
using UnityEngine;

namespace Editors
{
    [CustomEditor(typeof(Car))]
    public class CarEditor : Editor
    {
        // override the rendered component on the Editor
        public override void OnInspectorGUI()
        {
            Car myTarget = (Car)target;
            string label1 = "Gear Speed Limit";
            string tooltip1 = "This sets the maximum speed the car can reach in each gear.";
            EditorGUILayout.BeginHorizontal();  // Start horizontal layout
            myTarget.gearSpeedLimit = EditorGUILayout.IntField(new GUIContent(label1), myTarget.gearSpeedLimit);
            GUILayout.Button(new GUIContent("?", tooltip1), GUILayout.Width(20));
            EditorGUILayout.EndHorizontal();  // End horizontal layout

            string label2 = "Maximum Gears";
            string tooltip2 = "This sets the maximum available gears to next max speed level.";
            EditorGUILayout.BeginHorizontal();  // Start horizontal layout
            myTarget.gearAmount = EditorGUILayout.IntField(new GUIContent(label2), myTarget.gearAmount);
            GUILayout.Button(new GUIContent("?", tooltip2), GUILayout.Width(20));
            EditorGUILayout.EndHorizontal();  // End horizontal layout
            
            EditorGUILayout.LabelField("Total max speed", myTarget.MaxSpeed.ToString());
            EditorGUILayout.HelpBox("It calculates the max car speed!", MessageType.Info);

            if (myTarget.MaxSpeed >= 100)
            {
                EditorGUILayout.HelpBox("The speed is greater than the max (100) allowed value!", MessageType.Error);
            }
        }
    }
}
