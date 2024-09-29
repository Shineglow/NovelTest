using TestNovel.Scripts.ConfigurationScripts;
using UniRx;
using UnityEditor.U2D.Animation;
using UnityEngine;

namespace TestNovel.Scripts.Game.Characters
{
    public class CharacterModel : ICharacterModel
    {
        private CharacterConfiguration _characterConfiguration;

        public string Name => _characterConfiguration.Name.GetLocalizedString();
        
        public ReactiveProperty<ECharacterEmotions> ActualEmotion { get; } = new();
        public IReadOnlyReactiveProperty<ECharacterEmotions> Emotion => ActualEmotion;
        
        public ReactiveProperty<string> ActualCue { get; } = new();
        public IReadOnlyReactiveProperty<string> Cue => ActualCue;
        
        public Vector3ReactiveProperty Position { get; } = new();
        public IReadOnlyReactiveProperty<Vector3> CurrentPosition => Position;

        public ColorReactiveProperty Color { get; } = new ();
        public IReadOnlyReactiveProperty<Color> CurrentColor => Color;

        public void SetCharacterData(CharacterConfiguration characterConfiguration)
        {
            _characterConfiguration = characterConfiguration;
        }
    }
}