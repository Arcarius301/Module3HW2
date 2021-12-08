using System;
using System.Collections.Generic;
using System.Globalization;
using Module3HW2.Models;

namespace Module3HW2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Contact> contacts = new List<Contact>()
            {
                new Contact() { FirstName = "ЪJett", LastName = "Dickerson", PhoneNumber = "623-298-4464" },
                new Contact() { FirstName = "Ё2Jett", LastName = "Dickerson", PhoneNumber = "623-298-4464" },
                new Contact() { FirstName = "5Jett", LastName = "Dickerson", PhoneNumber = "623-298-4464" },
                new Contact() { FirstName = "6Jett", LastName = "Dickerson", PhoneNumber = "623-298-4464" },
                new Contact() { FirstName = "1Jett", LastName = "Dickerson", PhoneNumber = "623-298-4464" },
                new Contact() { FirstName = "0Jett", LastName = "Dickerson", PhoneNumber = "623-298-4464" },
                new Contact() { FirstName = "AJett", LastName = "Dickerson", PhoneNumber = "623-298-4464" },
                new Contact() { FirstName = "CJett", LastName = "Dickerson", PhoneNumber = "623-298-4464" },
                new Contact() { FirstName = "BJett", LastName = "Dickerson", PhoneNumber = "623-298-4464" },
                new Contact() { FirstName = "ЫJett", LastName = "Dickerson", PhoneNumber = "623-298-4464" },
            };

            contacts.Sort(new ContactComparer(CultureInfo.InvariantCulture));

            foreach (var contact in contacts)
            {
                Console.WriteLine(contact.FullName);
            }
        }
    }
}
