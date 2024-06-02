using System;
using System.Collections;
using NaughtyAttributes;
using UnityEngine;
using TMPro;
using UnityEditor;

namespace Utils
{
    public class Typer : MonoBehaviour
    {
        #region Public reference vars
        [Header("Public References")]
        public TextMeshProUGUI textMesh;
        #endregion

        #region Public config vars
        [Header("Public Config Vars")]
        public float timeBetweenChars = .1f;
        public string phrase = "";
        #endregion

        #region Unity Events

        private void Awake()
        {
            textMesh.text = "";
        }

        #endregion

        #region Coroutine Events Definition
        IEnumerator Type(string s)
        {
            textMesh.text = "";
            foreach (char c in s.ToCharArray())
            {
                textMesh.text += c;
                yield return new WaitForSeconds(timeBetweenChars);
            }
        }
        #endregion

        #region Tester Methods for Coroutines
        [Button]
        public void StartTyping()
        {
            if (!EditorApplication.isPlaying) return;
            StartCoroutine(Type(phrase));
        }
        #endregion
    }
}