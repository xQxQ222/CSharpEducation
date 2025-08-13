using System;

namespace EmployeeAccounting.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException(string message) : base(message) { }

        public ValidationException() : this("Ошибка валидации") { }
    }
}
