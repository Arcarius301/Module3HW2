using System;
using Module3HW2.Models;
using Module3HW2.Services;

namespace Module3HW2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configurationService = new ConfigurationService();
            ContactCollection contacts = new ContactCollection(configurationService.Config)
            {
                new Contact() { FirstName = "AAJohn", LastName = "Dillon", PhoneNumber = "380669999999" },
                new Contact() { FirstName = "0AJohn", LastName = "Dillon", PhoneNumber = "380669999999" },
                new Contact() { FirstName = "1GJohn", LastName = "Dillon", PhoneNumber = "380669999999" },
                new Contact() { FirstName = "00XJohn", LastName = "Dillon", PhoneNumber = "380669999999" },
                new Contact() { FirstName = "AAAJohn", LastName = "Dillon", PhoneNumber = "380669999999" },
                new Contact() { FirstName = "John", LastName = "Dillon", PhoneNumber = "380669999999" },
                new Contact() { FirstName = "3CJohn", LastName = "Dillon", PhoneNumber = "380669999999" },
                new Contact() { FirstName = "5DJohn", LastName = "Dillon", PhoneNumber = "380669999999" },
                new Contact() { FirstName = "ЫJohn", LastName = "Dillon", PhoneNumber = "380669999999" },
                new Contact() { FirstName = "ЯBJohn", LastName = "Dillon", PhoneNumber = "380669999999" },
                new Contact() { FirstName = "ФAJohn", LastName = "Dillon", PhoneNumber = "380669999999" },
                new Contact() { FirstName = "ЙЙAAJohn", LastName = "Dillon", PhoneNumber = "380669999999" },
                new Contact() { FirstName = "ёAAJohn", LastName = "Dillon", PhoneNumber = "380669999999" },
                new Contact() { FirstName = "яAAJohn", LastName = "Dillon", PhoneNumber = "380669999999" },
                new Contact() { FirstName = "уAAJohn", LastName = "Dillon", PhoneNumber = "380669999999" },
                new Contact() { FirstName = "тAAJohn", LastName = "Dillon", PhoneNumber = "380669999999" },
                new Contact() { FirstName = "AAJohn", LastName = "Dillon", PhoneNumber = "380669999999" },
                new Contact() { FirstName = "0AAJohn", LastName = "Dillon", PhoneNumber = "380669999999" },
                new Contact() { FirstName = "ZJohn", LastName = "Dillon", PhoneNumber = "380669999999" }
            };

            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"Group count: {contacts.GroupCount}");
            Console.WriteLine($"Contact count: {contacts.ContactCount}");

            foreach (var keyValuePair in contacts)
            {
                Console.WriteLine($"Group: {keyValuePair.Key}");
                foreach (var contact in keyValuePair.Value)
                {
                    Console.WriteLine(contact.FullName);
                }
            }

            contacts.ChangeCulture("ru_RU");
            contacts.RemoveGroup('#');
            contacts.RemoveContact(new Contact() { FirstName = "3CJohn", LastName = "Dillon", PhoneNumber = "380669999999" });

            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"Group count: {contacts.GroupCount}");
            Console.WriteLine($"Contact count: {contacts.ContactCount}");

            foreach (var keyValuePair in contacts)
            {
                Console.WriteLine($"Group: {keyValuePair.Key}");
                foreach (var contact in keyValuePair.Value)
                {
                    Console.WriteLine(contact.FullName);
                }
            }

            contacts.ChangeCulture("en_US");

            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"Group count: {contacts.GroupCount}");
            Console.WriteLine($"Contact count: {contacts.ContactCount}");

            foreach (var keyValuePair in contacts)
            {
                Console.WriteLine($"Group: {keyValuePair.Key}");
                foreach (var contact in keyValuePair.Value)
                {
                    Console.WriteLine(contact.FullName);
                }
            }
        }
    }
}
