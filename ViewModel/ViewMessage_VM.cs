using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectCF_Mobile_Version.Model;
using ProjectCF_Mobile_Version.Services;

namespace ProjectCF_Mobile_Version.ViewModel
{
    public partial class ViewMessage_VM : ObservableObject
    {
        public ViewMessage_VM(Message value)
        {
            SelectedMessage = value;
            CurrentEmployee = Employee_Services.InitializeCurrentEmployee();
        }
        [ObservableProperty]
        private Employee currentEmployee;
        [ObservableProperty]
        private Message selectedMessage;

        [RelayCommand]
        private async Task UpdateTag()
        {
            if (CurrentEmployee.JobPosition.Equals("Human Resource"))
            {
                string action = await Shell.Current.DisplayActionSheet("Change Status?", "Cancel", null, "Unread", "Read", "Pending","Approved","Denied");
                if(action == "Unread")
                    SelectedMessage.Tag = 0; //Changes tag to READ
                    Message_Services.UpdateMessageCollection(SelectedMessage);
                if (action == "Pending")
                    SelectedMessage.Tag = 2; //Changes tag to READ
                    Message_Services.UpdateMessageCollection(SelectedMessage);
                if (action == "Approved")
                    SelectedMessage.Tag = 3; //Changes tag to READ
                    Message_Services.UpdateMessageCollection(SelectedMessage);
                if (action == "Denied")
                    SelectedMessage.Tag = 4; //Changes tag to READ
                    Message_Services.UpdateMessageCollection(SelectedMessage);
            }
        }
    }
}
