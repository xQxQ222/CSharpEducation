using PhoneBook.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.UI
{
    public class ConsoleUI : UserInterface
    {
        private const string MENU = "1)Добавить новый контакт\n" +
            "2)Удалить контакт по номеру телефона\n" +
            "3)Обновить имя контакта\n" +
            "4)Обновить номер телефона контакта\n" +
            "5)Найти контакт по номеру телефона\n" +
            "6)Найти контакт по имени абонента\n" +
            "7)Выход";
        private readonly PhoneBookService phoneBookService;

        public ConsoleUI()
        {
            phoneBookService = new PhoneBookServiceImpl();
        }

        public void Start()
        {
            while (true)
            {
                Console.WriteLine(MENU);
                Console.Write("Введите пункт меню: ");
                char userInput = Console.ReadKey().KeyChar;
                Console.Write("\n");
                try
                {
                    switch (userInput)
                    {
                        case '1':
                            phoneBookService.AddNewContactToPhoneBook(UserInput.GetName(), UserInput.GetPhoneNumber());
                            break;
                        case '2':
                            phoneBookService.DeleteAbonent(UserInput.GetPhoneNumber());
                            break;
                        case '3':
                            phoneBookService.UpdateAbonentName(UserInput.GetPhoneNumber(), UserInput.GetName());
                            break;
                        case '4':
                            phoneBookService.UpdateAbonentPhoneNumber(UserInput.GetPhoneNumber(), UserInput.GetName());
                            break;
                        case '5':
                            UserOutput.PrintAbonentInfo(phoneBookService.GetAbonentByPhoneNumber(UserInput.GetPhoneNumber()));
                            break;
                        case '6':
                            UserOutput.PrintAbonentInfo(phoneBookService.GetAbonentByName(UserInput.GetName()));
                            break;
                        case '7':
                            phoneBookService.Exit();
                            break;
                        default:
                            Console.WriteLine("Такого пункта нет в меню!");
                            break;
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                WaitAndClearConsole();
            }
        }

        private void WaitAndClearConsole()
        {
            Console.WriteLine("Нажмите любую клавишу, чтобы продолжить....");
            Console.ReadKey(true);
            Console.Clear();
        }
    }
}
