using EmployeeAccounting.Dto;
using EmployeeAccounting.Models;
using System.Collections.Generic;

namespace EmployeeAccounting.Service
{
    public interface IPositionService
    {
        Position GetById(int id);
        List<Position> GetAll();
        void Delete(int id);
        Position Create(PositionDto dto);
        Position Update(int id, PositionDto dto);
    }
}
