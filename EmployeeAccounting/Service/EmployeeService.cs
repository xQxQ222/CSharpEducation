using EmployeeAccounting.Dto;
using EmployeeAccounting.Models;
using EmployeeAccounting.Storage;
using System.Collections.Generic;

namespace EmployeeAccounting.Service
{
    public class EmployeeService : IEmployeeService
    {
        Storage<Employee, EmployeeDto> storage;

        public EmployeeService()
        {
            storage = new EmployeeStorage();
        }
        public Employee Create(EmployeeDto employee)
        {
            return storage.Create(employee);
        }

        public void DeleteById(int id)
        {
            storage.DeleteById(id);
        }

        public List<Employee> GetAll()
        {
            return storage.GetAllValues();
        }

        public Employee GetById(int id)
        {
            return storage.GetById(id);
        }

        public Employee Update(int id, EmployeeDto employee)
        {
            return storage.Update(id, employee);
        }
    }
}
