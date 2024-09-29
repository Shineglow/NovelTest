using System;
using TestNovel.Scripts.Game.Gameplay.Root.View;
using UnityEngine;
using UnityEngine.UI;

namespace TestNovel.Scripts.Game.Gameplay
{
    public class Background : MonoBehaviour, IBackgroundClickHandler, IBackgroundView
    {
        [SerializeField] private Image _backgroundImage;
        [SerializeField] private Button _backgroundButton;

        public event Action BackgroundClicked;

        private void Awake()
        {
            _backgroundButton.onClick.AddListener(() => BackgroundClicked?.Invoke());
        }

        public void SetBackgroundImage(Sprite sprite)
        {
            _backgroundImage.sprite = sprite;
        }
    }
}