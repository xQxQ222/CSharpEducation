using EmployeeAccounting.Exceptions;
using EmployeeAccounting.Models;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeAccounting.Storage
{
    public abstract class Storage<M, D> where M : BaseEntity where D : class
    {
        private int currentId { get; set; } = 0;
        protected Dictionary<int, M> Store { get; private set; } = new Dictionary<int, M>();

        public virtual M GetById(int id)
        {
            var value = Store.Values.Where(x => x.Id == id).FirstOrDefault();
            if (value is null)
            {
                throw new NotFoundException(id);
            }
            return value;
        }

        public virtual List<M> GetAllValues()
        {
            return Store.Values.ToList();
        }

        public virtual void DeleteById(int id)
        {
            if (!Store.ContainsKey(id))
            {
                throw new NotFoundException(id);
            }
            Store.Remove(id);
        }

        public abstract M Update(int id, D entityToUpdate);

        public abstract M Create(D entityToCreate);

        protected int GetNextId()
        {
            return ++currentId;
        }
    }
}
