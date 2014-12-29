using System;
using System.Windows.Input;

namespace PayBook
{
    public class RelayCommand : ICommand
    {
        #region Constructors

        public RelayCommand(Action<object> execute)
            : this(execute, null)
        { }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null) throw new ArgumentNullException("execute");

            this._execute = execute;
            this._canExecute = canExecute;
        }

        #endregion

        #region ICommand

        private readonly Predicate<object> _canExecute;

        private readonly Action<object> _execute;

        public bool CanExecute(object parameter)
        {
            return this._canExecute == null || this._canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            this._execute(parameter);
        }

        #endregion
    }
}