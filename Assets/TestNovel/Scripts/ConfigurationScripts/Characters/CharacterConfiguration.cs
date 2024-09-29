using UnityEngine;
using UnityEngine.Localization;

namespace TestNovel.Scripts.ConfigurationScripts
{
    [CreateAssetMenu(menuName = "Configuration/Characters/Character", fileName = "Character")]
    public class CharacterConfiguration : ScriptableObject
    {
        [SerializeField] public ECharacters Character;
        [SerializeField] public LocalizedString Name;
        [SerializeField] public CharacterEmotionsConfiguration CharacterEmotionsToViews;
    }
}