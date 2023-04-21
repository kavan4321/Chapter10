using CommunityToolkit.Maui.Alerts;

namespace Chapter10.View.Exercise2View;

public partial class ChangeProfileScreen : ContentPage
{
	public ChangeProfileScreen()
	{
		InitializeComponent();
	}

    private async void TapGestureRecognizerTapped(object sender, TappedEventArgs e)
    {
		string action = await DisplayActionSheet("Change Profile", "Cancel","Delete", "Camera", "Gallery", "Avatar");
		_=Toast.Make(action, CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
    }
}