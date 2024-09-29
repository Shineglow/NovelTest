using System;
using System.Collections.Generic;
using UnityEngine;

namespace TestNovel.Scripts.ConfigurationScripts
{
    [CreateAssetMenu(menuName = "Configuration/Characters/CharactersConfiguration", fileName = "CharactersConfiguration")]
    public class CharactersConfiguration : ScriptableObject
    {
        public List<CharacterToConfiguration> CharactersToConfiguration;
    }

    [Serializable]
    public class CharacterToConfiguration
    {
        public ECharacters Character => CharacterConfiguration.Character;
        [SerializeField] public CharacterConfiguration CharacterConfiguration;
    }
}