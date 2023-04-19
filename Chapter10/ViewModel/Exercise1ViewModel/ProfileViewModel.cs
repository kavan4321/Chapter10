using Chapter10.HttpModel.Exercise1;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Chapter10.ViewModel.Exercise1ViewModel.ViewModelProfile
{
    public class ProfileViewModel
    {
        private AddDetailsResponceModel _responceDetails;
        public AddDetailsResponceModel ResponceDetails
        {
            get => _responceDetails;
            set
            {
                _responceDetails = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
