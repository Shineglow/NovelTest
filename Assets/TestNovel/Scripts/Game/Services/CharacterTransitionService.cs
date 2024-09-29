using Cysharp.Threading.Tasks;
using DG.Tweening;
using TestNovel.Scripts.ConfigurationScripts;
using TestNovel.Scripts.Game.Characters;
using TestNovel.Scripts.Game.Gameplay.CharactersScene;
using UnityEngine;

namespace TestNovel.Scripts.Game.Services
{
    public class CharacterTransitionService : ICharacterTransitionService, ISkipable
    {
        private readonly CharactersSceneModel _model;
        private bool _skipAnimation;

        public CharacterTransitionService(CharactersSceneModel model)
        {
            _model = model;
        }

        public async UniTask TransitCharacter(CharacterModel characterModel, CharacterTransitionData transitionData)
        {
            if (!float.IsNaN(transitionData.From.xCoordinate))
            {
                var from = _model.Size;
                from.y = 0;
                from.x *= transitionData.From.xCoordinate;
                
                characterModel.Position.Value = from;
            }
            
            var to = _model.Size;
            to.y = 0;
            to.x *= transitionData.To.xCoordinate;
            
            if (!float.IsNaN(transitionData.StartTransparency))
            {
                var color = characterModel.Color.Value;
                color.a = Mathf.Clamp01(transitionData.StartTransparency);
                characterModel.Color.Value = color;
            }

            var endTransparency = characterModel.Color.Value;
            endTransparency.a = Mathf.Clamp01(transitionData.StartTransparency);
            characterModel.Color.Value = endTransparency;

            var moveTween = DOTween.To(
                () => characterModel.Position.Value, 
                (Vector3 x) => characterModel.Position.Value = x, 
                to, 
                transitionData.Duration)
                .SetEase(Ease.Linear);
            
            var fadeTween = DOTween.To(
                () => characterModel.Color.Value, 
                (Color x) => characterModel.Color.Value = x, 
                endTransparency, 
                transitionData.Duration)
                .SetEase(Ease.Linear);

            IsPlay = true;
            await UniTask.WhenAny(
                UniTask.WhenAll(moveTween.AsyncWaitForCompletion().AsUniTask(), fadeTween.AsyncWaitForCompletion().AsUniTask()),
                UniTask.WaitUntil(() => _skipAnimation)
            );
            IsPlay = false;
            if (_skipAnimation)
            {
                moveTween.Complete();
                fadeTween.Complete();
            }

            _skipAnimation = false;
        }

        public void Skip()
        {
            _skipAnimation = true;
        }

        public bool IsPlay { get; private set; }
    }
}