using System;
using System.Collections.Generic;
using ConsoleMenuCreator.ConsoleLogManager;

namespace ConsoleMenuCreator
{
    public class MenuCreator<T>
    {
        private IDictionary<int, MenuItem<T>> _menuItems;
        private MenuActionManager<T> _actionManager;
        private int _selectedMenuItemNumber;
        private readonly string DefaultMenuName = "Menu";
        public String MenuName { get; set; }

        private int SelectedMenuItemNumber
        {
            get => _selectedMenuItemNumber;
            set => _selectedMenuItemNumber = CorrectValueIfNotInTheRangeMenuItems(value);
        }

        public MenuCreator()
        {
            _menuItems = new Dictionary<int, MenuItem<T>>();
            _actionManager = new MenuActionManager<T>(_menuItems);
            MenuName = DefaultMenuName;
        }

        public void AddMenuItem(Action action, String label)
        {
            var newMenuItem = new MenuItem<T>(action, label);
            _menuItems.Add(_menuItems.Count, newMenuItem);
        }

        public void AddMenuItem(Action<T> action, String label, T parameter)
        {
            var newMenuItem = new MenuItem<T>(action, label, parameter);
            _menuItems.Add(_menuItems.Count, newMenuItem);
        }

        public ConsoleKeyInfo ShowMenu(ref bool exitProgram)
        {
            ConsoleKeyInfo pressedKey;
            DrawMenu();
            do
            {
                pressedKey = Console.ReadKey();
                exitProgram = HandlePressingKey(pressedKey);

            } while (!exitProgram);
            return pressedKey;
        }

        private void DrawMenu()
        {
            ConsoleLogger.Clear();
            ConsoleLogger.Log("..::{0}::..", ConsoleLogLevel.Success, MenuName);
            foreach (var key in _menuItems.Keys)
            {
                var menuItem = _menuItems[key];

                if (key == _selectedMenuItemNumber)
                    DrawSelectedMenuItem(menuItem);
                else
                    DrawMenuItem(menuItem);
            }
            ConsoleLogger.Log("Press Esc to exit.\n");
        }

        private bool HandlePressingKey(ConsoleKeyInfo pressedKey)
        {
            var selectedMenuItemNumberCopy = SelectedMenuItemNumber;
            var closeProgramKey = _actionManager.HandlePressingKey(pressedKey, ref selectedMenuItemNumberCopy);

            if (selectedMenuItemNumberCopy != SelectedMenuItemNumber)
            {
                SelectedMenuItemNumber = selectedMenuItemNumberCopy;
                DrawMenu();
            }

            return closeProgramKey;
        }

        private int CorrectValueIfNotInTheRangeMenuItems(int value)
        {
            var maxValue = _menuItems.Count > 0 ? _menuItems.Count - 1 : 0;

            if (value < 0)
                return maxValue;
            else if (value > maxValue)
                return 0;
            else
                return value;
        }

        private void DrawSelectedMenuItem(MenuItem<T> menuItem) => ConsoleLogger.Log("{1}  {0}", ConsoleLogLevel.Highlighted, menuItem.Label, '*');

        private void DrawMenuItem(MenuItem<T> menuItem) => ConsoleLogger.Log("{1}  {0}", ConsoleLogLevel.Information, menuItem.Label, ' ');
    }
}