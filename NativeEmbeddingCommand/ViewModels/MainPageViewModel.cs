using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NativeEmbeddingCommand.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public MainPageViewModel()
        {
            CounterClickCommand = new Command(CounterClick);
        }

        private string _imageSource = string.Empty;

        public string ImageSource
        {
            get => _imageSource;
            set
            {
                _imageSource = value;
                OnPropertyChanged();
            }
        }

        private int _count = 0;


        private string _counterBtnText = "Click Me";

        public string CounterBtnText
        {
            get => _counterBtnText;
            set
            {
                _counterBtnText = value;
                OnPropertyChanged();
            }
        }

        public ICommand CounterClickCommand { get; private set; }

        private void CounterClick()
        {
            _count++;

            if (_count == 1)
                CounterBtnText = $"Clicked {_count} time";
            else
                CounterBtnText = $"Clicked {_count} times";
        }

        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
