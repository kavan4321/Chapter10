
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Chapter10.ViewModel.Exercise3ViewModel.ViewModelChat
{
    public class ChatDetails
    {
        public string Name { get; set; }    
        public string Description { get; set; }
        public string ImageSource { get; set; }

    }
    public class ChatViewModel:INotifyPropertyChanged
    {

        public ObservableCollection<ChatDetails> ChatDetails { get; set; }

        public ICommand DeleteCommand { get;private set; }
        public event EventHandler<ChatDetails> DeleteEvent;
        public ChatViewModel() 
        {
            ChatDetails = new ObservableCollection<ChatDetails>
            {
                new ChatDetails()
                {
                    Name="Rohit Sharma",
                    Description="Hello there could you please send us those files",
                    ImageSource="user1"
                },
                 new ChatDetails()
                {
                    Name="Smriti mandhana",
                    Description="Thank i will have look on this as soon as possible",
                    ImageSource="user4"
                },
                  new ChatDetails()
                {
                    Name="Virat Kohli",
                    Description="Hello there could you please send us files",
                    ImageSource="user3"
                },
                   new ChatDetails()
                {
                    Name="Elon Musk",
                    Description="Thank i will have look on this as soon as possible",
                    ImageSource="user5"
                },
            };
            DeleteCommand = new Command<ChatDetails>(DeleteData);
        }

        public void DeleteData(ChatDetails chatDetails)
        {
            DeleteEvent?.Invoke(this,chatDetails);
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
