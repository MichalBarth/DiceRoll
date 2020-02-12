using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OneDie.ViewModels
{
    class RelayCommand : ICommand
    {
        private Action _execute;
        private readonly Func<bool> _canExecute;

        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) //test, zda lze command provést
        {
            if (_canExecute != null)
            {
                return _canExecute();
            }
            return true;
        }

        public void Execute(object parameter) //provedení commandu
        {
            if (_execute != null)
            {
                _execute();
            }
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs()); //výzva k překleslení
        }
    }
}
