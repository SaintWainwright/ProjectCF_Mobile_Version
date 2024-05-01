﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectCF_Mobile_Version.Model;
using ProjectCF_Mobile_Version.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ProjectCF_Mobile_Version.ViewModel
{
    public partial class WriteMessage_VM : LandingPage_VM
    {
        private readonly Employee_Services employee_Services;
        private readonly Message_Services message_Services;
        [ObservableProperty]
        private ObservableCollection<Employee> contactList;
        [ObservableProperty]
        private Message newMessage;
        public WriteMessage_VM()
        {
            employee_Services = new Employee_Services();
            message_Services = new Message_Services();
            CurrentEmployee = employee_Services.InitializeCurrentEmployee();
            ContactList = employee_Services.GetHumanResources();
            newMessage = new Message();
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
        [RelayCommand]
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
    }
}
