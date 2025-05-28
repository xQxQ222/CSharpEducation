using PhoneBook.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.UI
{
    public class UserOutput
    {
        public static void PrintAbonentInfo(Abonent abonent)
        {
            Console.WriteLine($"Абонент. Имя: {abonent.Name}. Номер телефона: {abonent.PhoneNumber}");
        }
    }
}
