using System;
using UnityEngine;

namespace TestNovel.Scripts.Game.Gameplay.CharactersScene
{
    public class CharactersSceneModel : MonoBehaviour
    {
        public Vector2 Position => Vector2.zero;
        public Vector2 Size { get; } = new Vector2(1920, 1080);

        [field: SerializeField]
        public RectTransform CharactersActingScene { get; private set; }
    }
}