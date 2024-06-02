using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

namespace Button
{
    public class ButtonScale : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        #region Public config vars
        public float finalScale = 1.2f;
        public float scaleDuration = .1f;
        #endregion

        #region Private config & logical vars
        private Vector3 _defaultScale;
        private Tween _currentTween;
        #endregion
        
        #region Interfaces Implementation
        public void OnPointerEnter(PointerEventData eventData)
        {
            Debug.Log("OnPointer ENTER");
            // transform.localScale = Vector3.one * finalScale;
            _currentTween = transform.DOScale(_defaultScale * finalScale, scaleDuration);
        }
        
        public void OnPointerExit(PointerEventData eventData)
        {
            Debug.Log("OnPointer EXIT");
            // transform.localScale = Vector3.one;
            _currentTween.Kill();
            transform.DOScale(_defaultScale, scaleDuration);
        }
        #endregion

        #region Unity Events
        private void Awake()
        {
            Debug.Log($"ButtonScale Start: {gameObject.name} localScale before assignment: {transform.localScale}");
            _defaultScale = transform.localScale;
            Debug.Log($"ButtonScale Start: {gameObject.name} _defaultScale after assignment: {_defaultScale}");
        }
        #endregion
    }
}
