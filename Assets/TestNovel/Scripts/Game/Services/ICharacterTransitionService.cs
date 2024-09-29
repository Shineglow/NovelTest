using Cysharp.Threading.Tasks;
using TestNovel.Scripts.ConfigurationScripts;
using TestNovel.Scripts.Game.Characters;

namespace TestNovel.Scripts.Game.Services
{
    public interface ICharacterTransitionService
    {
        UniTask TransitCharacter(CharacterModel characterModel, CharacterTransitionData transitionData);
        void Skip();
    }
}