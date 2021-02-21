using ConsoleMenuCreator;
using ConsoleMenuCreator.ConsoleLogManager;
using System;

namespace ExampleConsoleMenu
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowMainMenu();
        }

        private static void ShowMainMenu()
        {
            ConsoleKeyInfo pressedKey;
            bool exitProgram = false;

            var menu = new MenuCreator<int>();
            menu.AddMenuItem(ShowSubMenu, "Show sub menu");
            menu.AddMenuItem(ShowRandomValue, "Operacja 1", 20);
            menu.AddMenuItem(ShowRandomValue, "Operacja 2", 30);
            menu.AddMenuItem(ShowRandomValue, "Operacja 3", 40);
            menu.AddMenuItem(ShowHelloWord, "Show hello world");

            pressedKey = menu.ShowMenu(ref exitProgram);
        }

        public static void ShowSubMenu()
        {
            ConsoleKeyInfo pressedKey;
            bool exitProgram = false;

            var menu = new MenuCreator<int>();
            menu.AddMenuItem(ShowRandomValue, "Operacja 0", 10);
            menu.AddMenuItem(ShowRandomValue, "Operacja 1", 20);
            menu.AddMenuItem(ShowRandomValue, "Operacja 2", 30);
            menu.AddMenuItem(ShowRandomValue, "Operacja 3", 40);
            menu.AddMenuItem(ShowMainMenu, "Powrót do pierwszego menu");

            pressedKey = menu.ShowMenu(ref exitProgram);
        }

        #region Examples Action
        public static void ShowRandomValue(int maxValue)
        {
            var r = new Random();
            var value = r.Next(maxValue);
            ConsoleLogger.Log(value.ToString());
        }

        public static void ShowHelloWord() => ConsoleLogger.Log("Hello Word", ConsoleLogLevel.Highlighted);

        #endregion
    }
}
