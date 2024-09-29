using System;
using Game.Gameplay.Root.Model;
using Game.GameRoot;
using TestNovel.Scripts.Game.Gameplay.Root.View;
using TestNovel.Scripts.Game.Services;
using UnityEngine;
using Zenject;

namespace Game.Gameplay.Root
{
    public class GameplayEntryPoint : MonoBehaviour
    {
        public event Action GoToMainMenuSceneRequested;
        
        [SerializeField] private UIGameplayRootViewAbstract sceneRootPrefab;

        private UIGameplayRootModelProxy _uiGameplayRootModel;
        private ILanguageService _languageService;
        
        public void Initialize(DiContainer diContainer, UIGameplayRootModel model)
        {
            _languageService = diContainer.Resolve<ILanguageService>();
            _uiGameplayRootModel = new UIGameplayRootModelProxy(model);
        }

        public void Run(UIRootView uiRoot)
        {
            var uiScene = Instantiate(sceneRootPrefab);
            uiRoot.AttachSceneUI(uiScene.gameObject);
            
            uiScene.SetPauseMenuActive(false);
            uiScene.SetLanguageMenuActive(false);

            uiScene.GoToMainMenuButtonClicked += () =>
            {
                GoToMainMenuSceneRequested?.Invoke();
            };
            uiScene.ShowMenuButtonClicked += () =>
            {
                uiScene.SetPauseMenuActive(true);
            };
            uiScene.HideMenuButtonClicked += () =>
            {
                uiScene.SetPauseMenuActive(false);
            };
            uiScene.ChangeLanguageButtonClicked += () =>
            {
                SetLanguageMenuActive(!_uiGameplayRootModel.IsLanguageMenuActive.Value);
            };
            uiScene.RussianLanguageSwitchRequested += () => 
            {
                SetLanguageMenuActive(false);
                _languageService.ChangeLanguage(Languages.RUSSIAN);
            };
            uiScene.EnglishLanguageSwitchRequested += () => 
            {
                SetLanguageMenuActive(false);
                _languageService.ChangeLanguage(Languages.ENGLISH);
            };

            void SetLanguageMenuActive(bool isActive)
            {
                _uiGameplayRootModel.IsLanguageMenuActive.Value = isActive;
                uiScene.SetLanguageMenuActive(isActive);
            }
        }
    }
}