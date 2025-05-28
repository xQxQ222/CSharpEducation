using PhoneBook.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PhoneBook.Storage
{
    public class PhoneBookStorage
    {
        private static PhoneBookStorage instance;

        public Dictionary<string, Abonent> abonentsDictionary { get; set; }
        private readonly string _filePath;

        private PhoneBookStorage()
        {
            _filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "phonebook.txt");
            CreateFile();
            LoadFromFile();
        }

        public static PhoneBookStorage GetInstance()
        {
            if (instance == null)
                instance = new PhoneBookStorage();
            return instance;
        }

        private void LoadFromFile()
        {
            abonentsDictionary = new Dictionary<string, Abonent>();
            if (!File.Exists(_filePath))
            {
                throw new FileNotFoundException("Файл не найден");
            }
            string lines = File.ReadAllText(_filePath);
            try
            {
                List<Abonent> abonents = JsonSerializer.Deserialize<List<Abonent>>(lines);
                foreach (var a in abonents)
                {
                    abonentsDictionary.Add(a.PhoneNumber, a);
                }
            }
            catch (Exception ex)
            {

            }
        }

        public async void LoadToFile()
        {
            await File.WriteAllTextAsync(_filePath, JsonSerializer.Serialize(abonentsDictionary.Values));
        }

        private void CreateFile()
        {
            if (!File.Exists(_filePath))
            {
                using (File.Create(_filePath)) { }
            }
        }
    }
}
