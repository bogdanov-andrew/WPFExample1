using System;
using System.Windows.Input;

namespace WPFExample1
{
    public class DelegateCommand : ICommand
    {
        private readonly Action _action;
        private readonly Func<bool> _canExecuteFunc;

        public DelegateCommand(Action action)
        {
            _action = action;
        }

        public DelegateCommand(Action action, Func<bool> canExecuteFunc)
            : this(action)
        {
            _canExecuteFunc = canExecuteFunc;
        }

        public void Execute(object parameter)
        {
            _action();
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecuteFunc != null)
            {
                return _canExecuteFunc();
            }

            return true;
        }

        public event EventHandler CanExecuteChanged;
    }

    public class DelegateCommand<T> : ICommand where T : class
    {
        private readonly Action<T> _action;
        private readonly Func<bool> _canExecuteFunc;

        public DelegateCommand(Action<T> action)
        {
            _action = action;
        }

        public DelegateCommand(Action<T> action, Func<bool> canExecuteFunc)
            : this(action)
        {
            _canExecuteFunc = canExecuteFunc;
        }

        public void Execute(object parameter)
        {
            _action(parameter as T);
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecuteFunc != null)
            {
                return _canExecuteFunc();
            }

            return true;
        }

        public event EventHandler CanExecuteChanged;
    }
}