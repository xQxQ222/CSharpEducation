using PhoneBook.Exceptions;
using PhoneBook.Model;
using PhoneBook.Service;

namespace PhoneBookTests
{
    public class AddTests
    {
        private readonly IPhoneBookService phoneBookService = PhoneBookService.Instance;
        [Fact]
        public void AddNewPhoneTest()
        {
            Assert.Throws<NotFoundException>(() => phoneBookService.GetAbonentByName("Иван"));
            phoneBookService.AddNewContactToPhoneBook("Иван", "88005553535");
            //Проверка на отсутствие ошибки при попытке получить нового абонента по имени
            var exeption = Record.Exception(() => phoneBookService.GetAbonentByName("Иван"));
            Assert.Null(exeption);
        }

        [Fact]
        public void AddContactWithSameNameTest()
        {
            string georgeName = "Георгий";

            Assert.Throws<NotFoundException>(() => phoneBookService.GetAbonentByName(georgeName));

            phoneBookService.AddNewContactToPhoneBook(georgeName, "89553554532");
            var george = phoneBookService.GetAbonentByName(georgeName);
            Assert.NotEmpty(george);
            Assert.Single(george);

            phoneBookService.AddNewContactToPhoneBook(georgeName, "89512005566");
            var abonents = phoneBookService.GetAbonentByName(georgeName);
            Assert.NotEmpty(abonents);
            Assert.Equal(2, abonents.Count());
        }

        [Fact]
        public void AddContactWithSamePhoneTest()
        {
            string testPhone = "89001112233";
            phoneBookService.AddNewContactToPhoneBook("Олег", testPhone);
            Assert.Throws<AlreadyExistException>(() => phoneBookService.AddNewContactToPhoneBook("Дарья", testPhone));
        }

        [Fact]
        public void NonValidPhoneTest()
        {
            string nonValidPhone = "89425r98429085";
            string shortPhone = "89";
            string emptyPhone = string.Empty;
            Assert.Throws<ArgumentException>(() => phoneBookService.AddNewContactToPhoneBook("Тест", nonValidPhone));
            Assert.Throws<ArgumentException>(() => phoneBookService.AddNewContactToPhoneBook("Тест", shortPhone));
            Assert.Throws<ArgumentException>(() => phoneBookService.AddNewContactToPhoneBook("Тест", emptyPhone));
        }

        [Fact]
        public void NonValidAbonentNameTest()
        {
            string emptyName = string.Empty;
            Assert.Throws<ArgumentNullException>(() => phoneBookService.AddNewContactToPhoneBook(emptyName, "89000000000"));
        }
    }
}