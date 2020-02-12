using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OneDie.ViewModels
{
    class MainViewModel : INotifyPropertyChanged
    {
        private int _number;
        private int _max;
        private Random _random;

        public MainViewModel()
        {
            _random = new Random();
            Max = 6;
            RollDie();
            Roll = new RelayCommand(
                    RollDie,
                    () => { if (Max <= 10) return true; return false; }
                    );

            SetMax = new ParametrizedRelayCommand(
                    (parameter) =>
                    {
                        if (Int32.TryParse(parameter as string, out int result))
                        {
                            Max = result;
                        }
                        if (Roll.CanExecute(null)) Roll.Execute(null);
                        Roll.RaiseCanExecuteChanged();
                    },
                    (parameter) => { return true; }
                ); 
        }

        public void RollDie()
        {
            Number = _random.Next(Max) + 1;
        }

        public int Number
        {
            get { return _number; }
            set
            {
                _number = value;
                NotifyPropertyChanged();
            }
        }
        public int Max
        {
            get { return _max; }
            set
            {
                _max = value;
                NotifyPropertyChanged();
            }
        }

        public RelayCommand Roll { get; set; }

        public ParametrizedRelayCommand SetMax { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
