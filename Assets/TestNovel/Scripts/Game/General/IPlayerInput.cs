using System;

namespace TestNovel.Scripts.Game
{
    public interface IPlayerInput
    {
        public event Action ShowNextFrame;
    }
}