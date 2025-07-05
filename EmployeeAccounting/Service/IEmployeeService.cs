using EmployeeAccounting.Dto;
using EmployeeAccounting.Models;
using System.Collections.Generic;

namespace EmployeeAccounting.Service
{
    public interface IEmployeeService
    {
        Employee GetById(int id);
        List<Employee> GetAll();
        void DeleteById(int id);
        Employee Create(EmployeeDto employee);
        Employee Update(int id, EmployeeDto employee);
    }
}
