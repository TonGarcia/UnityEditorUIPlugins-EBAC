using Managers;
using UnityEngine;

namespace Screen
{
    public class ScreenHelper : MonoBehaviour
    {
        public ScreenType screenType;

        public void onCLick()
        {
            ScreenManager.Instance.ShowByType(screenType);
        }
    }
}
