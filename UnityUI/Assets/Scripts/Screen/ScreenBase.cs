using System.Collections.Generic;
using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;

namespace Screen
{
    public enum ScreenType
    {
        Panel,
        InfoPanel,
        Shop
    }
    
    public class ScreenBase : MonoBehaviour
    {
        #region Public Editor Attributes
        [Header("Config Vars")]
        public ScreenType screenType;
        public bool startHidden = false;
        public List<Transform> uiElements;

        [Header("Animations")] 
        public float animationDuration = .3f;
        public float delayBetweenElements = .05f;
        #endregion

        #region Unity Events
        // Start is called before the first frame update
        void Start()
        {
            if (startHidden) HideElements();
        }

        // Update is called once per frame
        void Update()
        {
        
        }
        #endregion

        #region Protected Overridable Methods
        [Button] // NaughtyAttributes --> create EditorButton to test the method
        protected virtual void Show()
        {
            Debug.Log("ScreenBase SHOW Called");
            ShowElements();
        }
        
        [Button] // NaughtyAttributes --> create EditorButton to test the method
        protected virtual void Hide()
        {
            Debug.Log("ScreenBase HIDE Called");
            HideElements();
        }
        #endregion

        #region Private methods
        private void HideElements()
        {
            DisplayUIElements(false);   
        }

        private void ShowElements()
        {
            DisplayUIElements(true);
        }

        private void DisplayUIElements(bool active, bool animated = true)
        {
            if(!animated) uiElements.ForEach(i => i.gameObject.SetActive(active));
            else
            {
                var uiCounter = 0;
                foreach (var uiElement in uiElements)
                {
                    uiElement.DOScale(0, animationDuration).From().SetDelay(uiCounter * delayBetweenElements);
                    uiElement.gameObject.SetActive(active);
                    uiCounter++;
                }
            }
        }
        #endregion
    }
}
