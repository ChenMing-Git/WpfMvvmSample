using System;
using System.Windows.Input;

namespace WpfMvvmSample
{
    internal class DelegateCommand : ICommand
    {
        private Action<object> _Execute;
        private Func<object, bool> _CanExecute;

        public DelegateCommand(Action<object> Execute)
          : this(Execute, null)
        {
        }

        public DelegateCommand(Action<object> Execute, Func<object, bool> CanExecute)
        {
            this._Execute = Execute;
            this._CanExecute = CanExecute;
        }

        #region ICommand

        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged()
          => CanExecuteChanged?.Invoke(this, EventArgs.Empty);

        public bool CanExecute(object parameter)
          => (this._CanExecute != null) ? this._CanExecute(parameter) : true;

        public void Execute(object parameter)
        {
            if (this._Execute != null)
            {
                this._Execute(parameter);
            }
        }

        #endregion ICommand
    }
}