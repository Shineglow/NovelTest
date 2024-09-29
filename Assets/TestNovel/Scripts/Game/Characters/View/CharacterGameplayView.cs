using UnityEngine;
using UnityEngine.UI;

namespace TestNovel.Scripts.Game.Characters
{
    [RequireComponent(typeof(RectTransform))]
    public class CharacterGameplayView : MonoBehaviour, ICharacterGameplayView
    {
        private RectTransform _transform;
        private Image _characterImage;

        public RectTransform RectTransform => _transform;
        public Graphic CharacterGraphic => _characterImage;
        
        private void Awake()
        {
            _transform = GetComponent<RectTransform>();
        }

        public void SetView(Sprite sprite)
        {
            _characterImage.sprite = sprite;
        }

        public void SetPosition(Vector3 position)
        {
            _transform.position = position;
        }
    }

    public interface ICharacterGameplayView
    {
        void SetView(Sprite sprite);
        void SetPosition(Vector3 position);
    }
}