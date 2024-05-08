using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectCF_Mobile_Version.Model;
using ProjectCF_Mobile_Version.Services;
using System.Collections.ObjectModel;

namespace ProjectCF_Mobile_Version.ViewModel
{
    public partial class WriteMessage_VM : ObservableObject
    {
        public WriteMessage_VM() 
        {
            NewMessage = new Message();
            CurrentEmployee = Employee_Services.InitializeCurrentEmployee();
            ContactList = Employee_Services.GetHumanResources();
        }
        [ObservableProperty]
        private ObservableCollection<Employee> contactList;
        [ObservableProperty]
        private Message newMessage;
        [ObservableProperty]
        private Employee currentEmployee;
        private void InitializeMessage()
        {
            NewMessage.Sender = new Employee
            {
                EmployeeID = CurrentEmployee.EmployeeID,
                FullName = CurrentEmployee.FullName,
                Email = CurrentEmployee.Email,
                Password = CurrentEmployee.Password,
                ContactNumber = CurrentEmployee.ContactNumber,
                Gender = CurrentEmployee.Gender,
                Image = CurrentEmployee.Image,
                HoursWorked = CurrentEmployee.HoursWorked,
                ActivtiyStatus = CurrentEmployee.ActivtiyStatus,
                JobPosition = CurrentEmployee.JobPosition,
                DateJoined = CurrentEmployee.DateJoined,
                BirthDate = CurrentEmployee.BirthDate,
                Country = CurrentEmployee.Country,
                HomeAddress = CurrentEmployee.HomeAddress,
                ProvincialAddress = CurrentEmployee.ProvincialAddress
            };
            NewMessage.Tag = 0;
            NewMessage.TimeSent = DateTime.Now;
        }

        private bool ValidateEntries()
        {
            if (string.IsNullOrEmpty(NewMessage.Subject) || string.IsNullOrEmpty(NewMessage.MessageText) || NewMessage.Receiver == null)
                return false;
            return true;
        }
        [RelayCommand]
        private async Task SendMessage()
        {
            if (ValidateEntries())
            {
                InitializeMessage();
                Message_Services.SendMessage(NewMessage);
                await Shell.Current.DisplayAlert("Email sent", "The email has been successfully sent to receiver", "Okay");
                await Shell.Current.Navigation.PopToRootAsync();
                //Shell.Current.GoToAsync("..");
            }
            else
            {
                await Shell.Current.DisplayAlert("Entries not filled", "Fill in all entries to send message", "Okay");
            }
        }
        /*public void OnAppearing()
        {
            NewMessage = new Message();
            CurrentEmployee = Employee_Services.InitializeCurrentEmployee();
            ContactList = Employee_Services.GetHumanResources();
        }*/
    }
}
