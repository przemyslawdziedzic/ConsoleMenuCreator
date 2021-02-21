using System;

namespace ConsoleMenuCreator.MenuElement
{
    internal class SimpleAction : IMenuAction
    {
        private Action _action;

        internal SimpleAction(Action action) => _action = action;

        public virtual void Invoke() => _action.Invoke();
    }
}