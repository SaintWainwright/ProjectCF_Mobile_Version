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
        string filePath = Path.Combine(FileSystem.Current.AppDataDirectory, "Employee.txt");
        public ObservableCollection<Employee> GetEmployees()
        {
            if (!File.Exists(filePath))
            {
                return new ObservableCollection<Employee>();
            }

            string FileUsers = File.ReadAllText(filePath);
            var EmployeeList = JsonSerializer.Deserialize<ObservableCollection<Employee>>(FileUsers);

            return EmployeeList;
        }
    }
}
