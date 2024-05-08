using CommunityToolkit.Mvvm.ComponentModel;
using ProjectCF_Mobile_Version.Model;

namespace ProjectCF_Mobile_Version.ViewModel
{
    public partial class ViewMessage_VM : ObservableObject
    {
        public ViewMessage_VM(Message value)
        {
            SelectedMessage = value;
        }
        [ObservableProperty]
        private Message selectedMessage;
    }
}
