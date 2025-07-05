using System;

namespace EmployeeAccounting.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(int id) : base($"Объект с id {id} не найден") { }
    }
}
