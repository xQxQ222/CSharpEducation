using EmployeeAccounting.Exceptions;

namespace EmployeeAccounting.Dto
{
    public class PositionDto
    {
        private const float MinimumWageInRubles = 22400;

        private string name;
        private float? salary;

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ValidationException("Название должности не должно быть пустым");
                }
                name = value;
            }
        }

        public float? Salary
        {
            get { return salary; }
            set
            {
                if (value < MinimumWageInRubles)
                {
                    throw new ValidationException("Заработная плата не может быть меньше МРОТ");
                }
                salary = value;
            }
        }

        public PositionDto(string name, float? salary)
        {
            this.name = name;
            this.salary = salary;
        }
    }
}
