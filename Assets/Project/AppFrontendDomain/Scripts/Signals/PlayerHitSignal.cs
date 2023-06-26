namespace Project.AppFrontendDomain.Signals
{
    public class PlayerHitSignal : IUpdateViewSignal
    {
        private int _lives;
        public int Lives => _lives;

        public PlayerHitSignal(int lives)
        {
            _lives = lives;
        }
    }
}