using Chapter10.HttpModel.Exercise1;
using Chapter10.ViewModel.Exercise1ViewModel.ViewModelProfile;

namespace Chapter10.View.Exercise1View;

public partial class ProfileScreen : ContentPage
{
	private ProfileViewModel _profileViewModel;
	public ProfileScreen(AddDetailsResponceModel responceModel)
	{
		InitializeComponent();
		_profileViewModel=(ProfileViewModel)BindingContext;
		_profileViewModel.ResponceDetails = responceModel;
	}
}