using EmployeeAccounting.Dto;
using EmployeeAccounting.Models;

namespace EmployeeAccounting.Storage
{
    public class PositionStorage : Storage<Position, PositionDto>
    {
        public override Position Create(PositionDto entityToCreate)
        {
            var id = GetNextId();
            var newPosition = new Position(id, entityToCreate.Name, entityToCreate.Salary.Value);
            Store.Add(id, newPosition);
            return newPosition;
        }

        public override Position Update(int id, PositionDto entityToUpdate)
        {
            var positionFromStorage = GetById(id);
            if (entityToUpdate.Salary.HasValue)
            {
                positionFromStorage.Salary = entityToUpdate.Salary.Value;
            }
            Store[id] = positionFromStorage;
            return positionFromStorage;
        }
    }
}
