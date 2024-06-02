using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Button
{
    public class ButtonScale : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        #region Interfaces Implementation
        public void OnPointerEnter(PointerEventData eventData)
        {
            Debug.Log("OnPointer ENTER");
            transform.localScale = Vector3.one * 1.2f;
        }
        
        public void OnPointerExit(PointerEventData eventData)
        {
            Debug.Log("OnPointer EXIT");
            transform.localScale = Vector3.one;
        }
        #endregion
    }
}
