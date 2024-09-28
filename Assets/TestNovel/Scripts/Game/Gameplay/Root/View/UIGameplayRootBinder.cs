using System;
using UnityEngine;

namespace TestNovel.Scripts.Game.Gameplay.Root.View
{
    public class UIGameplayRootBinder : MonoBehaviour
    {
        public event Action GoToMainMenuButtonClicked;

        public void HandleGoToMainMenuButtonClicked()
        {
            GoToMainMenuButtonClicked?.Invoke();
        }
    }
}
