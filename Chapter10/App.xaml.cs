using Chapter10.View;
using Chapter10.View.Exercise1View;
using Chapter10.View.Exercise2View;
using Chapter10.View.Exercise3View;
using Chapter10.View.Exercise4View;
using Chapter10.View.Exercise5View;

namespace Chapter10;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new ButtomSheetScreen())
		{ BarBackgroundColor = Colors.DarkCyan };

	}
}
