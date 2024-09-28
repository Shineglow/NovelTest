using UnityEngine;

namespace TestNovel.Scripts.ConfigurationScripts
{
    [CreateAssetMenu(menuName = "Configuration/Chapter", fileName = "Chapter")]
    public class Chapter : ScriptableObject
    {
        public string Title;
    }
}