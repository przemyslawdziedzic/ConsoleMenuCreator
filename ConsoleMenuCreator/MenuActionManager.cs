using System;
using System.Collections.Generic;

namespace ConsoleMenuCreator
{
    internal class MenuActionManager<T>
    {
        private IDictionary<int, MenuItem<T>> _menuItems;

        public MenuActionManager(IDictionary<int, MenuItem<T>> menuItems) => _menuItems = menuItems;

        internal bool HandlePressingKey(ConsoleKeyInfo pressedKey, ref int selectedMenuItemNumber)
        {
            switch (pressedKey.Key)
            {
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    return true;
                case ConsoleKey.UpArrow:
                    selectedMenuItemNumber--;
                    break;
                case ConsoleKey.DownArrow:
                    selectedMenuItemNumber++;
                    break;
                case ConsoleKey.Enter:
                case ConsoleKey.RightArrow:
                    _menuItems[selectedMenuItemNumber].InvokeAction();
                    break;
            }
            return false;
        }
    }
}