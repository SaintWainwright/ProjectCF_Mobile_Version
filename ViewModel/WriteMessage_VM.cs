using ProjectCF_Mobile_Version.Model;
using ProjectCF_Mobile_Version.Services;
using ProjectCF_Mobile_Version.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjectCF_Mobile_Version.ViewModel
{
    public partial class WriteMessage_VM : LandingPage_VM
    {
        public WriteMessage_VM() 
        {
            NewMessage = new Message();
            employee_Services = new Employee_Services();
            message_Services = new Message_Services();
            InitializeContactList();
        }
        private readonly Employee_Services employee_Services;
        private readonly Message_Services message_Services;
        private void InitializeContactList()
        {
            ContactList = employee_Services.GetEmployees();
        }
        private ObservableCollection<Employee> contactList;
        public ObservableCollection<Employee> ContactList
        {
            get { return contactList; }
            set { contactList = value; OnPropertyChanged(); OnPropertyChanged(nameof(ContactList)); } 
        }
        private Message newMessage;
        public Message NewMessage
        {
            get { return newMessage; }
            set { newMessage = value; OnPropertyChanged(); OnPropertyChanged(nameof(newMessage)); }
        }
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
            {
                return false;
            }
            return true;
        }

        private void SendMessage()
        {
            if (ValidateEntries())
            {
                InitializeMessage();
                message_Services.SendMessage(NewMessage);
                Shell.Current.DisplayAlert("Email sent", "The email has been successfully sent to receiver", "Okay");
                Shell.Current.GoToAsync("..");
            }
            else
            {
                Shell.Current.DisplayAlert("Entries not filled", "Fill in all entries to send message", "Okay");
            }
        }
        public ICommand SendMessageCommand => new Command(SendMessage);
    }
}
