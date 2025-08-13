using EmployeeAccounting.Exceptions;
using EmployeeAccounting.Models;

namespace EmployeeAccounting.Dto
{
    public class EmployeeDto
    {
        private const int MinimumAgeAllowed = 18;
        private const int MaximumAgeAllowed = 70;
        private string name;
        private int? age;
        private Position position;

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ValidationException("Имя сотрудника не может быть пустым");
                }
                name = value;
            }
        }

        public int? Age
        {
            get { return age; }
            set
            {
                if (value < MinimumAgeAllowed)
                {
                    throw new ValidationException($"Возраст сотрудника должен быть больше {MinimumAgeAllowed}");
                }
                if (value > MaximumAgeAllowed)
                {
                    throw new ValidationException($"Возраст сотрудника должен быть меньше {MaximumAgeAllowed}");
                }
                age = value;
            }
        }

        public Position Position
        {
            get { return position; }
            set
            {
                if (value is null)
                {
                    throw new ValidationException("Должность сотрудника не должна быть пустым значением");
                }
                position = value;
            }
        }

        public EmployeeDto(string name, int age, Position position)
        {
            Name = name;
            Age = age;
            Position = position;
        }
    }
}
