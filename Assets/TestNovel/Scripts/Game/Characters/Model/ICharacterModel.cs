using TestNovel.Scripts.ConfigurationScripts;
using UniRx;
using UnityEngine;

namespace TestNovel.Scripts.Game.Characters
{
    public interface ICharacterModel
    {
        string Name { get; }
        IReadOnlyReactiveProperty<ECharacterEmotions> Emotion { get; }
        IReadOnlyReactiveProperty<Vector3> CurrentPosition { get; }
    }
}