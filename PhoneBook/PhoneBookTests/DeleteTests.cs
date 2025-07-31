using PhoneBook.Exceptions;
using PhoneBook.Model;
using PhoneBook.Service;

namespace PhoneBookTests
{
    public class DeleteTests
    {
        private readonly IPhoneBookService phoneBookService = PhoneBookService.Instance;

        [Fact]
        public void CorrectDeleteTest()
        {
            string phoneToDelete = "88005553535";
            string name = "Иван";
            phoneBookService.AddNewContactToPhoneBook(name, phoneToDelete);
            phoneBookService.AddNewContactToPhoneBook(name, "89512223344");

            List<Abonent> abonents = phoneBookService.GetAbonentByName(name);
            Assert.Equal(2, abonents.Count);

            phoneBookService.DeleteAbonent(phoneToDelete);

            abonents = phoneBookService.GetAbonentByName(name);
            Assert.Single(abonents);
        }

        [Fact]
        public void DeleteNonExistingPhoneTest()
        {
            string notExistingNumber = "89993334477";
            phoneBookService.AddNewContactToPhoneBook("Елисей", "89338880044");
            Assert.Throws<NotFoundException>(() => phoneBookService.DeleteAbonent(notExistingNumber));
        }
    }
}
