using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectCF_Mobile_Version.Model;
using ProjectCF_Mobile_Version.Services;
using ProjectCF_Mobile_Version.View;
using System.Collections.ObjectModel;

namespace ProjectCF_Mobile_Version.ViewModel
{
    public partial class Messaging_VM : ObservableObject
    {
        public Messaging_VM() 
        {
            CurrentEmployee = Employee_Services.InitializeCurrentEmployee();
        }
        [ObservableProperty]
        private Employee currentEmployee;
        [ObservableProperty]
        private ObservableCollection<Message> messageList;
        [ObservableProperty]
        private Message selectedMessage;
        partial void OnSelectedMessageChanged(Message value)
        {
            if(value.Receiver.EmployeeID == CurrentEmployee.EmployeeID)
            {
                value.Tag = 1; //Changes tag to READ
                Message_Services.UpdateMessageCollection(value);
            }
            Shell.Current.Navigation.PushAsync(new ViewMessage(value));
        }

        [RelayCommand]
        private async static Task GoToWriteMessage() => await Shell.Current.Navigation.PushAsync(new WriteMessage());

        public void OnAppearing()
        {
            MessageList = Message_Services.EmployeeMessageList(CurrentEmployee);
        }
        public void OnDisappearing()
        {
            SelectedMessage = null;
        }
    }
}
