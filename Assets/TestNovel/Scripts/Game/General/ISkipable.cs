namespace TestNovel.Scripts.Game
{
    public interface ISkipable
    {
        void Skip();
        bool IsPlay { get; }
    }
}