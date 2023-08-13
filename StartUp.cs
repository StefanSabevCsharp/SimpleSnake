namespace SimpleSnake
{
    using SimpleSnake.GameObjects;
    using System;
    using Utilities;

    public class StartUp
    {
        public static void Main()
        {
            ConsoleWindow.CustomizeConsole();


            Wall wall = new Wall(80, 20);
        }
    }
}
