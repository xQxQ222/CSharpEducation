namespace EmployeeAccounting.Models
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public Position Position { get; set; }

        public Employee(int id, string name, int age, Position position)
        {
            Id = id;
            Name = name;
            Age = age;
            Position = position;
        }
    }
}
