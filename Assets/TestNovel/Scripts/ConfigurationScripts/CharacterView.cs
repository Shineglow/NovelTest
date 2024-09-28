using UnityEngine;

namespace TestNovel.Scripts.ConfigurationScripts
{
    [CreateAssetMenu(menuName = "Configuration/CharacterView", fileName = "CharacterView")]
    public class CharacterView : ScriptableObject
    {
        [SerializeField] public Texture2D MainView;
    }
}