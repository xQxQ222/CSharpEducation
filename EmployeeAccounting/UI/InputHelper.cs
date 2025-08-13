using EmployeeAccounting.Dto;
using System;

namespace EmployeeAccounting.UI
{
    internal class InputHelper
    {
        public EmployeeDto InputNewEmployee()
        {
            Console.Write("Введите имя нового сотрудника: ");
            var name = Console.ReadLine();
            Console.Write("Введите возраст сотрудника: ");
            int age = 0;
            while (!int.TryParse(Console.ReadLine(), out age))
            {
                throw new InvalidCastException("Ошибка при вводе возраста");
            }

        }

        public PositionDto InputNewPosition()
        {
            Console.Write("Введите название должности: ");
            var name = Console.ReadLine();
            Console.Write("Введите зарплату должности: ");
            float salary = 0;
            while (!float.TryParse(Console.ReadLine(), out salary))
            {
                throw new InvalidCastException("Ошибка при вводе зарплаты");
            }
            return new PositionDto(name, salary);
        }
    }
}
