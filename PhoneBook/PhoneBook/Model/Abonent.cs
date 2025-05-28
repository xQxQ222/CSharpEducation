using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PhoneBook.Model
{
    public class Abonent
    {
        private string name;
        private string phoneNumber;

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Имя абонента не может быть пустым");
                }
                name = value;
            }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Телефон не может быть пустым");
                }
                if (value.Length < 10 || value.Length > 12)
                {
                    throw new ArgumentException("Неверная длина телефонного номера");
                }
                phoneNumber = value;
            }
        }

        public Abonent(string name, string phoneNumber)
        {
            Name = name;
            PhoneNumber = phoneNumber;
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
