using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Module3HW2.Models;

namespace Module3HW2
{
    public class ContactCollection
    {
        private SortedSet<KeyValuePair<char, SortedSet<Contact>>> _groupedContacts;
        private Dictionary<string, string> _cultures;
        private string _currentCulture = CultureInfo.InvariantCulture.Name;

        public ContactCollection()
        {
            _cultures = new Dictionary<string, string>();
            _currentCulture = CultureInfo.InvariantCulture.Name;
            _groupedContacts = new SortedSet<KeyValuePair<char, SortedSet<Contact>>>(new GroupsComparer(GetPattern()));
        }

        public void Add(Contact contact)
        {
            var isFind = false;
            var group = char.ToLower(contact.FullName[0]);

            if (GetPattern().IndexOf(group) == -1)
            {
                foreach (var keyValue in _groupedContacts)
                {
                    if (keyValue.Key.Equals('#'))
                    {
                        keyValue.Value.Add(contact);
                        isFind = true;
                        break;
                    }
                }

                if (!isFind)
                {
                    var contacts = new SortedSet<Contact>(new ContactComparer(new CultureInfo(_currentCulture))) { contact };
                    _groupedContacts.Add(new KeyValuePair<char, SortedSet<Contact>>('#', contacts));
                }
            }
            else
            {
                foreach (var keyValue in _groupedContacts)
                {
                    if (group.Equals(keyValue.Key))
                    {
                        keyValue.Value.Add(contact);
                        isFind = true;
                    }
                }

                if (!isFind)
                {
                    var contacts = new SortedSet<Contact>(new ContactComparer(new CultureInfo(_currentCulture))) { contact };
                    _groupedContacts.Add(new KeyValuePair<char, SortedSet<Contact>>(group, contacts));
                }
            }
        }

        private string GetPattern()
        {
            var alphabet = "abcdefghiklmnopqrstvxyz";
            var numbers = "0123456789";
            if (_cultures.TryGetValue(_currentCulture, out alphabet))
            {
                return alphabet + numbers;
            }

            return alphabet + numbers;
        }
    }
}
