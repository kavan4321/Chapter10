using Chapter10.ViewModel.Exercise4ViewModel.ViewModelCar;

namespace Chapter10.View.Exercise4View;

public partial class CarSecurityScreen : ContentPage
{
	private CarViewModel _carViewModel;
	public CarSecurityScreen()
	{
		InitializeComponent();
		_carViewModel=(CarViewModel)BindingContext;
        _carViewModel.SecurityEvent +=SecurityEvent;
	}

    private async void SecurityEvent(object sender, EventArgs e)
    {
		string result = await DisplayPromptAsync("Enter Security", "Enter your secure PIN", "Confirm");
		if (result != null)
		{
			_carViewModel.ButtonLabel = "Disable Security";
			_carViewModel.TitleLabel = "ON";
        }
    }
}