using EmployeeAccounting.Dto;
using EmployeeAccounting.Models;

namespace EmployeeAccounting.Storage
{
    public class EmployeeStorage : Storage<Employee, EmployeeDto>
    {
        public override Employee Create(EmployeeDto entityToCreate)
        {
            var id = GetNextId();
            var newEmployee = new Employee(id, entityToCreate.Name, entityToCreate.Age.Value, entityToCreate.Position);
            Store.Add(id, newEmployee);
            return newEmployee;
        }

        public override Employee Update(int id, EmployeeDto entityToUpdate)
        {
            var employeeFromStorage = GetById(id);
            if (entityToUpdate.Name is not null)
            {
                employeeFromStorage.Name = entityToUpdate.Name;
            }
            if (entityToUpdate.Age.HasValue)
            {
                employeeFromStorage.Age = entityToUpdate.Age.Value;
            }
            if (entityToUpdate.Position is not null)
            {
                employeeFromStorage.Position = entityToUpdate.Position;
            }
            Store[id] = employeeFromStorage;
            return employeeFromStorage;
        }
    }
}
