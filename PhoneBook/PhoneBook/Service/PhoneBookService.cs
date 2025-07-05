using PhoneBook.Exceptions;
using PhoneBook.Model;
using PhoneBook.Storage;
using System;
using System.Linq;

namespace PhoneBook.Service
{
    public class PhoneBookService : IPhoneBookService
    {
        private readonly PhoneBookStorage _phoneBook;
        private static PhoneBookService _instance;

        public static IPhoneBookService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PhoneBookService();
                }
                return _instance;
            }
        }

        private PhoneBookService()
        {
            _phoneBook = PhoneBookStorage.GetInstance();
        }

        public Abonent GetAbonentByPhoneNumber(string phoneNumber)
        {
            if (!_phoneBook.abonentsDictionary.ContainsKey(phoneNumber))
            {
                throw new NotFoundException();
            }
            return _phoneBook.abonentsDictionary[phoneNumber];
        }

        public Abonent GetAbonentByName(string name)
        {
            Abonent abonent = _phoneBook.abonentsDictionary.Where(ab => ab.Value.Name.Equals(name)).FirstOrDefault().Value;
            if (abonent == null)
            {
                throw new NotFoundException();
            }
            return abonent;
        }

        public void DeleteAbonent(string phoneNumber)
        {
            if (!_phoneBook.abonentsDictionary.ContainsKey(phoneNumber))
            {
                throw new NotFoundException();
            }
            _phoneBook.abonentsDictionary.Remove(phoneNumber);
        }

        public Abonent AddNewContactToPhoneBook(string name, string phoneNumber)
        {
            if (_phoneBook.abonentsDictionary.ContainsKey(name))
            {
                throw new AlreadyExistException($"Контакт с номером телефона {phoneNumber} уже существует");
            }
            Abonent abonent = new Abonent(name, phoneNumber);
            _phoneBook.abonentsDictionary.Add(phoneNumber, abonent);
            return abonent;
        }

        public Abonent UpdateAbonentName(string phoneNumber, string name)
        {
            if (!_phoneBook.abonentsDictionary.ContainsKey(phoneNumber))
            {
                throw new NotFoundException();
            }
            Abonent abonent = _phoneBook.abonentsDictionary[phoneNumber];
            abonent.Name = name;
            return abonent;
        }

        public Abonent UpdateAbonentPhoneNumber(string phoneNumber, string name)
        {
            int abonentsWithThatNameCount = _phoneBook.abonentsDictionary.Where(a => a.Value.Name.Equals(name)).Count();
            if (abonentsWithThatNameCount > 1)
            {
                throw new Exception("Невозможно изменить номер телефона абонента, т.к. абонентов с таким именем несколько");
            }
            if (abonentsWithThatNameCount == 0)
            {
                throw new Exception();
            }
            Abonent abonent = _phoneBook.abonentsDictionary.Where(a => a.Value.Name.Equals(name)).First().Value;
            abonent.PhoneNumber = phoneNumber;
            return abonent;
        }

        public void SaveBeforeExit()
        {
            _phoneBook.LoadToFile();
        }


    }
}
