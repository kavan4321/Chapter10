
using CommunityToolkit.Maui.Alerts;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Chapter10.ViewModel.Exercise4ViewModel.ViewModelCar
{
    public class CarViewModel:INotifyPropertyChanged
    {
        private string _buttonLabel= "Enable Security";
        private string _titleLabel="OFF";

        public string ButtonLabel
        {
            get => _buttonLabel;
            set
            {
                _buttonLabel = value;
                OnPropertyChanged();
            }
        }
        public string TitleLabel
        {
            get => _titleLabel;
            set
            {
                _titleLabel = value;
                OnPropertyChanged();
            }
        }

        public ICommand SecurityCommand { get;private set; }
        public event EventHandler SecurityEvent;
      
        public CarViewModel()
        {
            SecurityCommand = new Command(ChangeDetails);
        }

        public void ChangeDetails()
        {
            if(ButtonLabel== "Enable Security")
            {
                SecurityEvent?.Invoke(this, new EventArgs());
            }
            else
            {
                Toast.Make("Security is disable", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
                ButtonLabel = "Enable Security";
                TitleLabel = "OFF";
            }
            
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
