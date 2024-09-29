using System.Collections.Generic;
using TestNovel.Scripts.ConfigurationScripts;
using TestNovel.Scripts.Game.Characters;
using TestNovel.Scripts.Game.Gameplay.Root.View;
using TestNovel.Scripts.Game.Services;

namespace TestNovel.Scripts.Game.Gameplay
{
    public class ChaptersPlayer
    {
        private readonly IBackgroundView _backgroundView;
        private Chapter _chapterConfiguration;
        private readonly IEnumerable<ISkipable> _skipables;
        private readonly ICharacterTransitionService _characterTransitionService;

        private Dictionary<ECharacters, CharacterModel> _characterToModel = new();
        private Dictionary<ECharacters, CharacterConfiguration> _characterToConfiguration = new();

        private int _currentFrameIndex;

        public ChaptersPlayer(
            IPlayerInput playerInput, 
            IBackgroundView backgroundView, 
            ICharacterTransitionService characterTransitionService,
            CharactersConfiguration charactersConfiguration,
            IEnumerable<ISkipable> skipables)
        {
            _characterTransitionService = characterTransitionService;
            _skipables = skipables;
            
            charactersConfiguration.CharactersToConfiguration
                .ForEach(i => _characterToConfiguration.Add(i.Character, i.CharacterConfiguration));
            
            playerInput.ShowNextFrame += OnShowNextFrameRequested;
            _backgroundView = backgroundView;
        }

        private void OnShowNextFrameRequested()
        {
            bool somethingWasSkipped = false;
            foreach (var skipable in _skipables)
            {
                if (!skipable.IsPlay) continue;
                
                skipable.Skip();
                somethingWasSkipped = true;
            }
            if (somethingWasSkipped) return;

            Frame frame = _chapterConfiguration.Frames[++_currentFrameIndex];

            if (frame.BackgroundSwitchConfiguration.BackgroundImage != null)
            {
                _backgroundView.SetBackgroundImage(frame.BackgroundSwitchConfiguration.BackgroundImage);
            }
            
            foreach (var characterTransition in frame.ActingInFrame)
            {
                _characterTransitionService.TransitCharacter(
                    GetOrCreateModel(characterTransition.Character), characterTransition.CharacterTransitionData);
            }
        }

        public void PlayChapter(Chapter chapterConfiguration)
        {
            _chapterConfiguration = chapterConfiguration;
            _currentFrameIndex = -1;
            OnShowNextFrameRequested();
        }

        public CharacterModel GetOrCreateModel(ECharacters character)
        {
            if (_characterToModel.TryGetValue(character, out var model))
                return model;

            model = new CharacterModel();
            _characterToModel.Add(character, model);
            model.SetCharacterData(_characterToConfiguration[character]);

            return model;
        }
    }
}