using EmployeeAccounting.Dto;
using EmployeeAccounting.Models;
using EmployeeAccounting.Storage;
using System.Collections.Generic;

namespace EmployeeAccounting.Service
{
    public class PositionService : IPositionService
    {
        Storage<Position, PositionDto> positionStorage;

        public PositionService()
        {
            positionStorage = new PositionStorage();
        }
        public Position Create(PositionDto dto)
        {
            return positionStorage.Create(dto);
        }

        public void Delete(int id)
        {
            positionStorage.DeleteById(id);
        }

        public List<Position> GetAll()
        {
            return positionStorage.GetAllValues();
        }

        public Position GetById(int id)
        {
            return positionStorage.GetById(id);
        }

        public Position Update(int id, PositionDto dto)
        {
            return positionStorage.Update(id, dto);
        }
    }
}
