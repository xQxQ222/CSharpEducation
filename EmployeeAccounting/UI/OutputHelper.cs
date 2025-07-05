using EmployeeAccounting.Models;
using System;

namespace EmployeeAccounting.UI
{
    internal class OutputHelper
    {
        public void PrintEmployee(Employee employee)
        {
            Console.WriteLine($"""
                Сотрудник №{employee.Id}) Имя: {employee.Name}, Возраст: {employee.Age}, Должность: {employee.Position.Name}, Зарплата: {employee.Position.Salary.ToString("C")}
                """);
        }

        public void PrintPosition(Position position)
        {
            Console.WriteLine($"{position.Id})Должность: {position.Name}, Оклад: {position.Salary.ToString("C")}");
        }
    }
}
