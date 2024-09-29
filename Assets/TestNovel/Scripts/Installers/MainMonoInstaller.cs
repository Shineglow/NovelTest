using TestNovel.Scripts.Game.Gameplay;
using TestNovel.Scripts.Game.Services;
using Zenject;

public class MainMonoInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesTo<LanguageService>().FromNew().AsCached();
        Container.BindInterfacesTo<ChaptersPlayer>().FromNew().AsCached();
    }

    public DiContainer GetContainer() => Container;
}
