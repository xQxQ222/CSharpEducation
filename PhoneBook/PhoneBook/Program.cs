using PhoneBook.UI;

namespace PhoneBook
{
    class Program
    {
        static void Main()
        {
            UserInterface userInterface = new ConsoleUI();
            userInterface.Start();
        }
    }
}