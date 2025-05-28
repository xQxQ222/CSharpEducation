using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.UI
{
    public class UserInput
    {
        public static string GetPhoneNumber()
        {
            Console.Write("Введите номер телефона: ");
            return Console.ReadLine();
        }

        public static string GetName()
        {
            Console.Write("Введите имя абонента: ");
            return Console.ReadLine();
        }
    }
}
