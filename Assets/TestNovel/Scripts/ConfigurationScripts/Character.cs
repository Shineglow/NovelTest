using System;
using System.Collections.Generic;
using UnityEngine;

namespace TestNovel.Scripts.ConfigurationScripts
{
    [CreateAssetMenu(menuName = "Configuration/Character", fileName = "Character")]
    public class Character : ScriptableObject
    {
        [SerializeField] public string Name;
        [SerializeField] public List<CharacterViewToEmotion> CharacterViews;

        private static List<CharacterViewToEmotion> _cachedResult;
        public static IReadOnlyList<CharacterViewToEmotion> GetEmotionsToView()
        {
            if (_cachedResult == null)
            {
                var emotions = Enum.GetValues(typeof(ECharacterEmotions));
                _cachedResult = new(emotions.Length);
                foreach (ECharacterEmotions emotion in emotions)
                {
                    _cachedResult.Add(new()
                    {
                        Emotion = emotion,
                        CharacterView = null,
                    });
                }
            }
            
            return _cachedResult;
        }
    }

    [Serializable]
    public struct CharacterViewToEmotion
    {
        [SerializeField] public ECharacterEmotions Emotion;
        [SerializeField] public CharacterView CharacterView;
    }
}