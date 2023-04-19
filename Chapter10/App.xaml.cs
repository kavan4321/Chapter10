using Chapter10.View.Exercise1View;
using Chapter10.View.Exercise2View;

namespace Chapter10;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new ChangeProfileScreen())
		{ BarBackgroundColor = Colors.DarkCyan };

	}
}
