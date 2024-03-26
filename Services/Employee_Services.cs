using ProjectCF_Mobile_Version.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProjectCF_Mobile_Version.Services
{
    class Employee_Services
    {
        public ObservableCollection<Employee> GetEmployees()
        {
#if ANDROID
            var docsDirectory = Android.App.Application.Context.GetExternalFilesDir(Android.OS.Environment.DirectoryDocuments);
            File.WriteAllText($"{docsDirectory.AbsoluteFile.Path}/Initialization.json", "Initialize File path");
            if (!File.Exists($"{docsDirectory.AbsoluteFile.Path}/Employee.json"))
            {
                return new ObservableCollection<Employee>();
            }

            string FileUsers = File.ReadAllText($"{docsDirectory.AbsoluteFile.Path}/Employee.json");
            var EmployeeList = JsonSerializer.Deserialize<ObservableCollection<Employee>>(FileUsers);
            return EmployeeList;
#endif
#if WINDOWS
            string filePath = Path.Combine(FileSystem.Current.AppDataDirectory, "Employee.json");
            if (!File.Exists(filePath))
            {
                return new ObservableCollection<Employee>();
            }
            string FileUsers = File.ReadAllText(filePath);
            var EmployeeList = JsonSerializer.Deserialize<ObservableCollection<Employee>>(FileUsers);
            return EmployeeList;
#endif
        }
    }
}
