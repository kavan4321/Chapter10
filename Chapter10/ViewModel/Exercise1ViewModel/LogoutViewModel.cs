
using Chapter10.HttpModel.Exercise1;
using Chapter10.Interface;
using Chapter10.Model.Exercise1Model;
using CommunityToolkit.Maui.Alerts;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Chapter10.ViewModel.Exercise1ViewModel.ViewModelLogout
{
    public class LogoutViewModel : INotifyPropertyChanged
    {
        private AddDetailsModel _addDetailsModel;
        private string _userName;
        private string _password;
        private AddDetailsResponceModel _responceDetails;

        public string UserName
        {
            get => _userName;
            set
            {
                _userName = value;
                OnPropertyChanged();
            }
        }
        public string Password
        {
            get => _password;
            set
            {

                _password = value;
                OnPropertyChanged();
            }
        }
        public AddDetailsResponceModel ResponceDetails
        {
            get => _responceDetails;
            set
            {
                _responceDetails = value;
                OnPropertyChanged();
            }
        }

        public event EventHandler<AddDetailsResponceModel> SignInEvent;
        public ICommand SignInCommand { get;private set; }
        
        public LogoutViewModel()
        {
            _addDetailsModel=new AddDetailsModel();
            SignInCommand = new Command(Validation);
        }


        public async void Validation()
        {
            if(string.IsNullOrWhiteSpace(UserName) &&
                string.IsNullOrWhiteSpace(Password))
            {
                _=Toast.Make("Please enter values", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
            }
            else if (string.IsNullOrWhiteSpace(UserName))
            {
                _=Toast.Make("Please enter user name", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
            }
            else if (string.IsNullOrWhiteSpace(Password))
            {
               _= Toast.Make("Please enter password", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
            }
            else if (Password.Length<6)
            {
                _=Toast.Make("Password is too small", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
            }
            else
            {
                _addDetailsModel.Username= UserName;
                _addDetailsModel.Password= Password;
                var result=await _addDetailsModel.AddDetailsAsync();
                ResponceDetails=_addDetailsModel.ResponceDetails;
                SignInEvent?.Invoke(this, ResponceDetails);
            }
        }

        


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
