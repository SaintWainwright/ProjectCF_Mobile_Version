using ProjectCF_Mobile_Version.Model;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace ProjectCF_Mobile_Version.Services
{
    class Employee_Services
    {
        public static ObservableCollection<Employee> GetEmployees()
        {
#if ANDROID
            var docsDirectory = Android.App.Application.Context.GetExternalFilesDir(Android.OS.Environment.DirectoryDocuments);
            File.WriteAllText($"{docsDirectory.AbsoluteFile.Path}/Initialization.json", "Initialize File path");
            if (!File.Exists($"{docsDirectory.AbsoluteFile.Path}/Employee.json"))
            {
                return [];
            }

            string FileUsers = File.ReadAllText($"{docsDirectory.AbsoluteFile.Path}/Employee.json");
            var EmployeeList = JsonSerializer.Deserialize<ObservableCollection<Employee>>(FileUsers);
            return EmployeeList;
#else
            string filePath = Path.Combine(FileSystem.Current.AppDataDirectory, "Employee.json");
            if (!File.Exists(filePath))
            {
                return [];
            }
            string FileUsers = File.ReadAllText(filePath);
            var EmployeeList = JsonSerializer.Deserialize<ObservableCollection<Employee>>(FileUsers);
            return EmployeeList;
#endif
        }
        public static void UpdateEmployeeCollection(Employee employee)
        {
#if ANDROID
            var docsDirectory = Android.App.Application.Context.GetExternalFilesDir(Android.OS.Environment.DirectoryDocuments);
            ObservableCollection<Employee> EmployeeCollection = Employee_Services.GetEmployees();
            for (int loop = 0; loop < EmployeeCollection.Count; loop++)
            {
                if (employee.EmployeeID == EmployeeCollection[loop].EmployeeID)
                {
                    EmployeeCollection[loop] = employee;
                    var EmployeeList = JsonSerializer.Serialize<ObservableCollection<Employee>>(EmployeeCollection);
                    File.WriteAllText($"{docsDirectory.AbsoluteFile.Path}/Employee.json", EmployeeList);
                    return;
                }
            }
#else
            string filePath = Path.Combine(FileSystem.Current.AppDataDirectory, "Employee.json");
            ObservableCollection<Employee> EmployeeCollection = Employee_Services.GetEmployees();
            for (int loop = 0; loop < EmployeeCollection.Count; loop++)
            {
                if (employee.EmployeeID == EmployeeCollection[loop].EmployeeID)
                {
                    EmployeeCollection[loop] = employee;
                    var EmployeeList = JsonSerializer.Serialize<ObservableCollection<Employee>>(EmployeeCollection);
                    File.WriteAllText(filePath, EmployeeList);
                    return;
                }
            }
#endif
        }
        public static ObservableCollection<Employee> GetHumanResources()
        {
            ObservableCollection<Employee> EmployeeCollection = [];
            foreach (var employee in Employee_Services.GetEmployees())
            {
                if (employee.JobPosition == "Human Resource")
                {
                    EmployeeCollection.Add(employee);
                }
            }
            return EmployeeCollection;
        }
        public static Employee InitializeCurrentEmployee()
        {
            string employeeID = Preferences.Get("employeeID", "Unknown");
            foreach (var employee in Employee_Services.GetEmployees())
            {
                if (employeeID == employee.EmployeeID)
                {
                    return employee;
                }
            }
            return new();
        }
    }
}
