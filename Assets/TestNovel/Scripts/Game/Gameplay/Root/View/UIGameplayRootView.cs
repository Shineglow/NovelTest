using System;
using JetBrains.Annotations;

namespace TestNovel.Scripts.Game.Gameplay.Root.View
{
    public class UIGameplayRootView : UIGameplayRootViewAbstract
    {
        public override event Action GoToMainMenuButtonClicked;
        public override event Action ShowMenuButtonClicked;
        public override event Action HideMenuButtonClicked;
        public override event Action ChangeLanguageButtonClicked;
        public override event Action RussianLanguageSwitchRequested;
        public override event Action EnglishLanguageSwitchRequested;

        
        [UsedImplicitly] public void HandleGoToMainMenuButtonClicked()
        {
            GoToMainMenuButtonClicked?.Invoke();
        }
        
        [UsedImplicitly] public void HandleShowMenuButtonClicked()
        {
            ShowMenuButtonClicked?.Invoke();
        }
        
        [UsedImplicitly] public void HandleHideMenuButtonClicked()
        {
            HideMenuButtonClicked?.Invoke();
        }
        
        [UsedImplicitly] public void HandleChangeLanguageButtonClicked()
        {
            ChangeLanguageButtonClicked?.Invoke();
        }
        
        [UsedImplicitly] public void HandleRussianLanguageSwitchButtonClicked()
        {
            RussianLanguageSwitchRequested?.Invoke();
        }
        
        [UsedImplicitly] public void HandleEnglishLanguageSwitchButtonClicked()
        {
            EnglishLanguageSwitchRequested?.Invoke();
        }
    }
}