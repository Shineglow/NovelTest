using System;
using UnityEngine;

namespace TestNovel.Scripts.Game.Gameplay.Root.View
{
    public abstract class UIGameplayRootViewAbstract : MonoBehaviour
    {
        [SerializeField] private GameObject languageMenu;
        [SerializeField] private GameObject pauseMenu;
        
        public abstract event Action GoToMainMenuButtonClicked;
        public abstract event Action ShowMenuButtonClicked;
        public abstract event Action ChangeLanguageButtonClicked;
        
        public abstract event Action RussianLanguageSwitchRequested;
        public abstract event Action EnglishLanguageSwitchRequested;
        public abstract event Action HideMenuButtonClicked;

        public void SetLanguageMenuActive(bool isActive)
        {
            languageMenu.SetActive(isActive);
        }
        
        public void SetPauseMenuActive(bool isActive)
        {
            pauseMenu.SetActive(isActive);
        }
    }
}
