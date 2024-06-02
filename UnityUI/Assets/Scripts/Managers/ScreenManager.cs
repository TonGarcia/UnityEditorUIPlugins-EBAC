using System.Collections.Generic;
using Screen;
using Core;

namespace Managers
{
    public class ScreenManager : Singleton<ScreenManager>
    {
        public List<ScreenBase> screenBases;
        public ScreenType startScreen = ScreenType.Panel;

        private ScreenBase _currentScreenBase;

        private void Start()
        {
            HideAll();
            ShowByType(startScreen);
        }

        public void ShowByType(ScreenType screenType)
        {
            if(_currentScreenBase != null) _currentScreenBase.Hide();
            var nextScreen = screenBases.Find(i => i.screenType == screenType);
            _currentScreenBase = nextScreen;
            nextScreen.Show();
        }

        public void HideAll()
        {
            screenBases.ForEach(i => i.Hide());
        }
    }
}
