using System;

namespace TestNovel.Scripts.Game.Gameplay
{
    public interface IBackgroundClickHandler
    {
        event Action BackgroundClicked;
    }
}