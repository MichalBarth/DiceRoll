using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OneDie.ViewModels
{
    class ParametrizedRelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public ParametrizedRelayCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter) //test, zda lze command provést
        {
            if (_canExecute != null)
            {
                return _canExecute(parameter);
            }
            return true;
        }

        public void Execute(object parameter) //provedení commandu
        {
            if (_execute != null)
            {
                _execute(parameter);
            }
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs()); //výzva k překleslení
        }
    }
}
