using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

namespace TestNovel.Scripts.ConfigurationScripts
{
    [CreateAssetMenu(menuName = "Configuration/Chapters/Chapter", fileName = "Chapter")]
    public class Chapter : ScriptableObject
    {
        public LocalizedString Title;
        public List<Frame> Frames;
    }
}