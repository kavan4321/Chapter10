using Chapter10.ViewModel.Exercise1ViewModel.ViewModelLogout;
using CommunityToolkit.Maui.Alerts;

namespace Chapter10.View.Exercise1View;

public partial class LogoutConfirmationScreen : ContentPage
{
	private LogoutViewModel _logoutViewModel;
	public LogoutConfirmationScreen()
	{
		InitializeComponent();
		_logoutViewModel=(LogoutViewModel)BindingContext;
        _logoutViewModel.SignInEvent += SignInEvent;

	}

    private void SignInEvent(object sender, HttpModel.Exercise1.AddDetailsResponceModel e)
    {
        Navigation.PushAsync(new ProfileScreen(_logoutViewModel.ResponceDetails));
    }

   
}