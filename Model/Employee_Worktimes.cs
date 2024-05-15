using CommunityToolkit.Mvvm.ComponentModel;

namespace ProjectCF_Mobile_Version.Model
{
    public partial class Employee_Worktimes : ObservableObject
    {
        [ObservableProperty]
        private DateTime timeIn;
        [ObservableProperty]
        private DateTime timeOut;
        [ObservableProperty]
        private DateTime overtimes;
        [ObservableProperty]
        private DateTime undertimes;
        [ObservableProperty]
        private DateTime lates;
        [ObservableProperty]
        private DateTime hoursWorked;
        [ObservableProperty]
        private DateTime month;
        [ObservableProperty]
        private DateTime year;
    }
}
