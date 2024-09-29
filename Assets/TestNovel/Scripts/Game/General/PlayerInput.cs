using System;
using TestNovel.Scripts.Game.Gameplay;
using UnityEngine;
using Zenject;

namespace TestNovel.Scripts.Game
{
    public class PlayerInput : IPlayerInput, ITickable, IDisposable
    {
        public event Action ShowNextFrame;
        
        private readonly IBackgroundClickHandler _backgroundClickHandler;

        public PlayerInput(IBackgroundClickHandler backgroundClickHandler)
        {
            _backgroundClickHandler = backgroundClickHandler;
            backgroundClickHandler.BackgroundClicked += ShowNextFrameInvoke;
        }

        private void ShowNextFrameInvoke()
        {
            ShowNextFrame?.Invoke();
        }

        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ShowNextFrameInvoke();
            }
        }

        public void Dispose()
        {
            _backgroundClickHandler.BackgroundClicked -= ShowNextFrameInvoke;
        }
    }
}