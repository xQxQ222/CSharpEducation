using PhoneBook.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Service
{
    public interface PhoneBookService
    {
        Abonent GetAbonentByName(string name);
        Abonent GetAbonentByPhoneNumber(string phoneNumber);
        void DeleteAbonent(string phoneNumber);
        Abonent AddNewContactToPhoneBook(string name, string phoneNumber);
        Abonent UpdateAbonentName(string phoneNumber, string name);
        Abonent UpdateAbonentPhoneNumber(string phoneNumber, string name);
        void Exit();
    }
}
