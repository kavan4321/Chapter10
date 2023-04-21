namespace Chapter10.View.Exercise5View;

public partial class WebViewScreen : ContentPage
{
	public WebViewScreen()
	{
		InitializeComponent();
	}

    private void BackButtonClicked(object sender, EventArgs e)
    {
        if(webView.CanGoBack)
        {
            webView.GoBack();
        }
    }

    private void NextButtonClicked(object sender, EventArgs e)
    {
        if (webView.CanGoForward)
        {
            webView.GoForward();
        }
    }

    private async void LaunchButtonClicked(object sender, EventArgs e)
    {
        await Launcher.OpenAsync(" https://www.1rivet.com/contact-us");
    }
}