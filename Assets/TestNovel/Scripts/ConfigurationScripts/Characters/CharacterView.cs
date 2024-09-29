using UnityEngine;

namespace TestNovel.Scripts.ConfigurationScripts
{
    [CreateAssetMenu(menuName = "Configuration/Characters/CharacterView", fileName = "CharacterView")]
    public class CharacterView : ScriptableObject
    {
        [SerializeField] public Sprite MainView;
    }
}