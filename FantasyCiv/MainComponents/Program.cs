using System;

namespace FantasyCiv
{
    /// <summary>
    /// GameClass of MonoGame
    /// </summary>
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new GameController())
                game.Run();
        }
    }
}
