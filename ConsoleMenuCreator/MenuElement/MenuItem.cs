using System;
using ConsoleMenuCreator.MenuElement;

namespace ConsoleMenuCreator
{
    internal class MenuItem<T>
    {
        internal String Label { get; private set; }
        private IMenuAction _action;

        internal MenuItem(Action action, String label)
        {
            _action = new SimpleAction(action);
            Label = label;
        }

        internal MenuItem(Action<T> action, String label, T parameter)
        {
            _action = new ParameterizedAction<T>(action, parameter);
            Label = label;
        }

        internal void InvokeAction() => _action.Invoke();
    }
}