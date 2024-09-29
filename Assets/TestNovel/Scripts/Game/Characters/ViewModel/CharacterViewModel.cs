using System;
using System.Collections.Generic;
using TestNovel.Scripts.ConfigurationScripts;
using UniRx;

namespace TestNovel.Scripts.Game.Characters.ViewModel
{
    public class CharacterViewModel
    {
        private ICharacterModel _characterModel;
        private ICharacterGameplayView _characterView;
        private CharacterConfiguration _characterConfiguration;
        private Dictionary<ECharacterEmotions, CharacterView> _emotionsToView;

        public List<IDisposable> _disposables = new();

        public void Initialize(ICharacterModel characterModel, CharacterConfiguration characterConfiguration, ICharacterGameplayView initialView)
        {
            _characterConfiguration = characterConfiguration;

            _characterView = initialView;
            
            _emotionsToView = new Dictionary<ECharacterEmotions, CharacterView>(_characterConfiguration.CharacterEmotionsToViews.CharacterViews.Count);
            foreach (var view in _characterConfiguration.CharacterEmotionsToViews.CharacterViews)
            {
                _emotionsToView[view.Emotion] = view.CharacterView;
            }
            
            _characterModel = characterModel;
            characterModel.Emotion
                .Subscribe(e => _characterView.SetView(_emotionsToView[e].MainView))
                .AddTo(_disposables);
            characterModel.CurrentPosition
                .Subscribe(p => _characterView.SetPosition(p))
                .AddTo(_disposables);
        }

        public void SetView(ICharacterGameplayView view)
        {
            _characterView = view;
        }

        private void OnDestroy()
        {
            _disposables.ForEach(d => d.Dispose());
        }
    }
}