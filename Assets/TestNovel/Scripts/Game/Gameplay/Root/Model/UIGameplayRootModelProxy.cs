using UniRx;

namespace Game.Gameplay.Root.Model
{
    public class UIGameplayRootModelProxy
    {
        public ReactiveProperty<bool> IsPauseMenuActive;
        public ReactiveProperty<bool> IsLanguageMenuActive;
        
        public UIGameplayRootModelProxy(UIGameplayRootModel model)
        {
            IsPauseMenuActive = new(model.IsPauseMenuActive);
            IsLanguageMenuActive = new(model.IsLanguageMenuActive);

            IsPauseMenuActive.Subscribe(e => model.IsPauseMenuActive = e);
            IsLanguageMenuActive.Subscribe(e => model.IsLanguageMenuActive = e);
        }
    }
}