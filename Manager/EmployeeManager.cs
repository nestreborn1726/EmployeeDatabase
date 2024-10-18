﻿using Manager.EmployeeServices;
using static Models.EmployeeModel;

namespace Manager.EmployeeManager
{
    public class EmployeeManager : IEmployeeService
    {

        private readonly List<Employee> _employee = new List<Employee>
        {
            new Employee { Id = 1, FirstName = "Ernest", LastName = "Villareal", JobTitle = "Janitor" },
            new Employee { Id = 2, FirstName = "Bryan", LastName = "De Guzman", JobTitle = "CEO" }
        };


        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employee;
        }


        public Employee GetEmployeeById(int id)
        {
            return _employee.FirstOrDefault(s => s.Id == id);
        }
 
        public void AddEmployee(Employee employee)
        {
            employee.Id = _employee.Max(s => s.Id) + 1;
            _employee.Add(employee);
        }


        public void UpdateEmployee(int id, Employee employee)
        {
            var existingEmployee = _employee.FirstOrDefault(s => s.Id == id);
            if (existingEmployee != null)
            {
                existingEmployee.FirstName = employee.FirstName;
                existingEmployee.LastName = employee.LastName;
                existingEmployee.JobTitle = employee.JobTitle;
            }
        }

        public void DeleteEmployee(int id)
        {
            var employee = _employee.FirstOrDefault(s => s.Id == id);
            if (employee != null)
            {
                _employee.Remove(employee);
            }
        }
    }
}