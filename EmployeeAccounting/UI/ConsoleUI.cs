using EmployeeAccounting.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAccounting.UI
{
    public class ConsoleUI
    {
        private readonly IEmployeeService _employeeService;
        private readonly IPositionService _positionService;
        private const string ChoiseMenu = """
            1)Сотрудники
            2)Должности
            """;
        private const string EmployeeMenu = """
            1)Добавить нового сотрудника
            2)Удалить сотрудника
            3)Обновить данные сотрудника
            4)Найти сотрудника по id
            5)Вывести список всех сотрудников
            """;
        private const string PositionMenu = """
            1)Добавить новую должность
            2)Удалить должность
            3)Обновить зарплату должности
            4)Найти должность по id
            5)Вывести список всех должностей
            """;

        public ConsoleUI()
        {
            _employeeService = new EmployeeService();
            _positionService = new PositionService();
        }

        public void Start()
        {
            Console.WriteLine(ChoiseMenu);
        }
    }
}
