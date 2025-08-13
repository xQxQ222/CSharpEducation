using PhoneBook.Exceptions;
using PhoneBook.Model;
using PhoneBook.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookTests
{
    public class UpdateTests
    {
        private readonly IPhoneBookService phoneBookService = PhoneBookService.Instance;
        [Fact]
        public void UpdateNonExistingAbonentTest()
        {
            Assert.Throws<NotFoundException>(() => phoneBookService.UpdateAbonentName("88005553535", "Екатерина"));
        }

        [Fact]
        public void CorrectUpdateAbonentTest()
        {
            string name = "Елена";
            string phone = "89555009918";
            phoneBookService.AddNewContactToPhoneBook(name, phone);

            Abonent abonent = phoneBookService.GetAbonentByPhoneNumber(phone);
            Assert.Equal(name, abonent.Name);

            string newName = "Данил";
            phoneBookService.UpdateAbonentName(phone, newName);
            
            abonent = phoneBookService.GetAbonentByPhoneNumber(phone);

            Assert.NotEqual(name, abonent.Name);
            Assert.Equal(newName, abonent.Name);
        }

        /// <summary>
        /// Обновление телефона пользователя на уже существующий
        /// </summary>
        [Fact]
        public void UpdateToExistingPhoneTest()
        {
            string testPhone = "89999999999";
            phoneBookService.AddNewContactToPhoneBook("Тест1", testPhone);
            phoneBookService.AddNewContactToPhoneBook("Тест2", "89888888888");

        }
    }
}
