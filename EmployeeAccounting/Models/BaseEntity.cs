namespace EmployeeAccounting.Models
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
