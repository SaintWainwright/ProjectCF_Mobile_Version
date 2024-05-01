using CommunityToolkit.Mvvm.ComponentModel;
using ProjectCF_Mobile_Version.Model;

namespace ProjectCF_Mobile_Version.ViewModel
{
    [QueryProperty(nameof(SelectedMessage), "selectedmessage")]
    public partial class ViewMessage_VM : LandingPage_VM
    {
        [ObservableProperty]
        private Message selectedMessage;
    }
}
