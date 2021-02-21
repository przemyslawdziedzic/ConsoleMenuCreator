using System;

namespace ConsoleMenuCreator.MenuElement
{
    internal class ParameterizedAction<T> : IMenuAction
    {
        private Action<T> _action;
        private T _actionParameter;

        internal ParameterizedAction(Action<T> action, T parameter)
        {
            _action = action;
            _actionParameter = parameter;
        }

        public virtual void Invoke() => _action.Invoke(_actionParameter);
    }
}