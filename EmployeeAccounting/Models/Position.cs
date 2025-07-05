namespace EmployeeAccounting.Models
{
    public class Position : BaseEntity
    {
        public string Name { get; set; }
        public float Salary { get; set; }

        public Position(int id, string name, float salary)
        {
            Id = id;
            Name = name;
            Salary = salary;
        }
    }
}
