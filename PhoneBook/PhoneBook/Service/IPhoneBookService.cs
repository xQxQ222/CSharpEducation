using PhoneBook.Model;

namespace PhoneBook.Service
{
    public interface IPhoneBookService
    {
        static abstract IPhoneBookService Instance { get; }
        Abonent GetAbonentByName(string name);
        Abonent GetAbonentByPhoneNumber(string phoneNumber);
        void DeleteAbonent(string phoneNumber);
        Abonent AddNewContactToPhoneBook(string name, string phoneNumber);
        Abonent UpdateAbonentName(string phoneNumber, string name);
        Abonent UpdateAbonentPhoneNumber(string phoneNumber, string name);
        void SaveBeforeExit();
    }
}
