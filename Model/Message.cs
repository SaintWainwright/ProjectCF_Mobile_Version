using CommunityToolkit.Mvvm.ComponentModel;

namespace ProjectCF_Mobile_Version.Model
{
    public partial class Message : ObservableObject
    {
        [ObservableProperty]
        private Employee sender = new();
        [ObservableProperty]
        private Employee receiver = new();
        [ObservableProperty]
        private string subject;
        [ObservableProperty]
        private string messageText;
        [ObservableProperty]
        private int tag;
        [ObservableProperty]
        private DateTime timeSent;
    }
}
