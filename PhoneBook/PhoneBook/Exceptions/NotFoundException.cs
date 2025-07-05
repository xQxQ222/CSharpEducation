using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : base("Абонент не найден") { }
        public NotFoundException(string message) : base(message) { }
    }
}
