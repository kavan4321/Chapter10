namespace Chapter10.View;

public partial class ButtomSheetScreen : ContentPage
{
	public ButtomSheetScreen()
	{
		InitializeComponent();
	}



    private void TapGestureRecognizerTapped(object sender, TappedEventArgs e)
    {
		var page=new MySheetPage();
		page.IsModal = true;
		page.Show(Window);		
    }
}