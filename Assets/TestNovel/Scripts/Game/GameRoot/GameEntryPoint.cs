using System.Collections;
using System.Collections.Generic;
using Game.Gameplay.Root;
using Game.Gameplay.Root.Model;
using Game.GameRoot;
using TestNovel.Scripts.Game.Gameplay.CharactersScene;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utils;
using Zenject;

public class GameEntryPoint
{
    private static GameEntryPoint _instance;
    private Coroutines _coroutines;
    private UIRootView _uiRootView;
    
    private DiContainer _container;
    private MainMonoInstaller _mainMonoInstaller;
    private CharactersSceneModel _charactersSceneModel;

    private GameEntryPoint()
    {
        _coroutines = new GameObject("[COROUTINES]").AddComponent<Coroutines>();
        Object.DontDestroyOnLoad(_coroutines.gameObject);

        var prefabUIRoot = Resources.Load<UIRootView>("UIRoot");
        _uiRootView = Object.Instantiate(prefabUIRoot);
        _charactersSceneModel = _uiRootView.GetComponent<CharactersSceneModel>();
        Object.DontDestroyOnLoad(_uiRootView.gameObject);
    }
    
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void AutostartGame()
    {
        Application.targetFrameRate = 60;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        
        _instance ??= new GameEntryPoint();
        _instance.RunGame();
    }

    private void RunGame()
    {
#if UNITY_EDITOR
        var sceneName = SceneManager.GetActiveScene().name;

        if (sceneName == Scenes.GAMEPLAY)
        {
            _coroutines.StartCoroutine(LoadAndStartGameplay());
            return;
        }
        
        if (sceneName == Scenes.MAIN_MENU)
        {
            _coroutines.StartCoroutine(LoadAndStartMainMenu());
            return;
        }

        if (sceneName != Scenes.BOOT)
        {
            return;
        }
#endif

        _coroutines.StartCoroutine(LoadAndStartGameplay());
    }

    private IEnumerator LoadAndStartGameplay()
    {
        _uiRootView.ShowLoadingScreen();

        yield return LoadScene(Scenes.BOOT);
        yield return LoadScene(Scenes.GAMEPLAY);

        yield return new WaitForSeconds(2);

        var prefabMainMonoInstaller = Resources.Load<MainMonoInstaller>("MainMonoInstaller");
        _mainMonoInstaller = Object.Instantiate(prefabMainMonoInstaller);

        yield return null;

        var container = _mainMonoInstaller.GetContainer();

        var sceneEntryPoint = Object.FindObjectOfType<GameplayEntryPoint>();
        sceneEntryPoint.Initialize(container, new UIGameplayRootModel());
        sceneEntryPoint.Run(_uiRootView);
        container.BindInterfacesTo<GameplayEntryPoint>().FromInstance(sceneEntryPoint).AsCached();

        sceneEntryPoint.GoToMainMenuSceneRequested += () => _coroutines.StartCoroutine(LoadAndStartMainMenu());
        
        _uiRootView.HideLoadingScreen();
    }
    
    private IEnumerator LoadAndStartMainMenu()
    {
        _uiRootView.ShowLoadingScreen();

        yield return LoadScene(Scenes.BOOT);
        yield return LoadScene(Scenes.MAIN_MENU);

        yield return new WaitForSeconds(2);

        var sceneEntryPoint = Object.FindObjectOfType<MainMenuEntryPoint>();
        sceneEntryPoint.Run(_uiRootView);

        sceneEntryPoint.GoToGameplaySceneRequested += () => _coroutines.StartCoroutine(LoadAndStartGameplay());
        
        _uiRootView.HideLoadingScreen();
    }

    private IEnumerator LoadScene(string sceneName)
    {
        yield return SceneManager.LoadSceneAsync(sceneName);
    }
}
