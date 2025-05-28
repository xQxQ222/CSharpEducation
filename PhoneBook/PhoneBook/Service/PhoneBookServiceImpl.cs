using PhoneBook.Exceptions;
using PhoneBook.Model;
using PhoneBook.Storage;
using System;
using System.Linq;

namespace PhoneBook.Service
{
    public class PhoneBookServiceImpl : PhoneBookService
    {
        private readonly PhoneBookStorage _phoneBook;
        private const string ABONENT_NOT_FOUND_MESSAGE = "Абонент не найден";

        public PhoneBookServiceImpl()
        {
            _phoneBook = PhoneBookStorage.GetInstance();
        }

        public Abonent GetAbonentByPhoneNumber(string phoneNumber)
        {
            if (!_phoneBook.abonentsDictionary.ContainsKey(phoneNumber))
            {
                throw new NotFoundException(ABONENT_NOT_FOUND_MESSAGE);
            }
            return _phoneBook.abonentsDictionary[phoneNumber];
        }

        public Abonent GetAbonentByName(string name)
        {
            Abonent abonent = _phoneBook.abonentsDictionary.Where(ab => ab.Value.Name.Equals(name)).FirstOrDefault().Value;
            if (abonent == null)
            {
                throw new NotFoundException(ABONENT_NOT_FOUND_MESSAGE);
            }
            return abonent;
        }

        public void DeleteAbonent(string phoneNumber)
        {
            if (!_phoneBook.abonentsDictionary.ContainsKey(phoneNumber))
            {
                throw new NotFoundException(ABONENT_NOT_FOUND_MESSAGE);
            }
            _phoneBook.abonentsDictionary.Remove(phoneNumber);
            _phoneBook.LoadToFile();
        }

        public Abonent AddNewContactToPhoneBook(string name, string phoneNumber)
        {
            if (_phoneBook.abonentsDictionary.ContainsKey(name))
            {
                throw new AlreadyExistException($"Контакт с номером телефона {phoneNumber} уже существует");
            }
            Abonent abonent = new Abonent(name, phoneNumber);
            _phoneBook.abonentsDictionary.Add(phoneNumber, abonent);
            _phoneBook.LoadToFile();
            return abonent;
        }

        public Abonent UpdateAbonentName(string phoneNumber, string name)
        {
            if (!_phoneBook.abonentsDictionary.ContainsKey(phoneNumber))
            {
                throw new NotFoundException(ABONENT_NOT_FOUND_MESSAGE);
            }
            Abonent abonent = _phoneBook.abonentsDictionary[phoneNumber];
            abonent.Name = name;
            _phoneBook.LoadToFile();
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
                throw new Exception(ABONENT_NOT_FOUND_MESSAGE);
            }
            Abonent abonent = _phoneBook.abonentsDictionary.Where(a => a.Value.Name.Equals(name)).First().Value;
            abonent.PhoneNumber = phoneNumber;
            _phoneBook.LoadToFile();
            return abonent;
        }

        public void Exit()
        {
            _phoneBook.LoadToFile();
            Environment.Exit(0);
        }
    }
}
