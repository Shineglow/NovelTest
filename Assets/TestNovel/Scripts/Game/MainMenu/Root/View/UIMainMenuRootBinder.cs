using System;
using UnityEngine;

namespace Game.Gameplay.Root.Root.View
{
    public class UIMainMenuRootBinder : MonoBehaviour
    {
        public event Action GoToGameplayButtonClicked;

        public void HandleGoToGameplayButtonClicked()
        {
            GoToGameplayButtonClicked?.Invoke();
        }
    }
}