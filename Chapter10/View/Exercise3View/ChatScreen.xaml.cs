using Chapter10.ViewModel.Exercise3ViewModel.ViewModelChat;
using CommunityToolkit.Maui.Alerts;

namespace Chapter10.View.Exercise3View;

public partial class ChatScreen : ContentPage
{
	private ChatViewModel _chatViewModel;
	public ChatScreen()
	{
		InitializeComponent();
		_chatViewModel=(ChatViewModel)BindingContext;
        _chatViewModel.DeleteEvent += DeleteEvent; 
	}


    private async void DeleteEvent(object sender, ChatDetails e)
    {
		bool result = await DisplayAlert("Delete Chat", "Are you sure you want to delete this chat?", "Yes", "No");

		if (result)
		{
			_chatViewModel.ChatDetails.Remove(e);
			_=Toast.Make("Chat deleted successfully", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
		}
    }
}