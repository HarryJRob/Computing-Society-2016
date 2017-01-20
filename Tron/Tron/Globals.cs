namespace Tron
{
    public static class Globals
    {
        public enum GameState
        {
            MainMenu,
            PlayingGame
        }

        public static GameState CurrentGameState = GameState.MainMenu;
    }
}
