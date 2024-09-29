using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

namespace TestNovel.Scripts.ConfigurationScripts
{
    [CreateAssetMenu(menuName = "Configuration/Chapters/Frame", fileName = "Frame")]
    public class Frame : ScriptableObject
    {
        [Tooltip("Этот параметр означает, как и во что превратится задник фрейма. " +
                 "Если поле не будет инициализировано, то ничего не поменяется (и не проинициализируется).")]
        public BackgroundConfiguration BackgroundSwitchConfiguration;
        
        public List<CharacterTransition> ActingInFrame;
        public CueConfiguration ActualCue;
    }

    [Serializable]
    public class CharacterTransition
    {
        [SerializeField] public ECharacters Character;
        [SerializeField] public CharacterTransitionData CharacterTransitionData;
    }

    [Serializable]
    public class CueConfiguration
    {
        [SerializeField] public ECharacters Character;
        [SerializeField] public ECharacterEmotions Emotion;
        [SerializeField] public LocalizedString Cue;
    }
    
    [Serializable]
    public class BackgroundConfiguration
    {
        [SerializeField] public Sprite BackgroundImage;
    }
}