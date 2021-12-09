using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Module3HW2.Configurations;
using Module3HW2.Models;

namespace Module3HW2
{
    public class ContactCollection : IEnumerable<KeyValuePair<char, SortedSet<Contact>>>
    {
        private readonly Config _config;
        private SortedSet<KeyValuePair<char, SortedSet<Contact>>> _groupedContacts;
        private Dictionary<string, string> _cultures;
        private ContactComparer _contactComparer;
        private string _currentCulture;
        private string _pattern;

        public ContactCollection(Config config)
        {
            _config = config;
            Init();
        }

        public int GroupCount { get => _groupedContacts.Count; }

        public int ContactCount
        {
            get
            {
                var count = 0;
                foreach (var keyValuePair in _groupedContacts)
                {
                    count += keyValuePair.Value.Count;
                }

                return count;
            }
        }

        public void Add(Contact contact)
        {
            var isFind = false;
            var group = char.ToLower(contact.FullName[0]);

            if (_pattern.IndexOf(group) == -1)
            {
                group = '#';
            }

            foreach (var keyValuePair in _groupedContacts)
            {
                if (keyValuePair.Key.Equals(group))
                {
                    keyValuePair.Value.Add(contact);
                    isFind = true;
                    break;
                }
            }

            if (!isFind)
            {
                var contacts = new SortedSet<Contact>(_contactComparer) { contact };
                _groupedContacts.Add(new KeyValuePair<char, SortedSet<Contact>>(group, contacts));
            }
        }

        public bool RemoveGroup(char group)
        {
            foreach (var keyValuePair in _groupedContacts)
            {
                if (Equals(keyValuePair.Key, group))
                {
                    _groupedContacts.Remove(keyValuePair);
                    return true;
                }
            }

            return false;
        }

        public bool RemoveContact(Contact contact)
        {
            foreach (var keyValuePair in _groupedContacts)
            {
                foreach (var item in keyValuePair.Value)
                {
                    if (Equals(item, contact))
                    {
                        keyValuePair.Value.Remove(item);
                        if (keyValuePair.Value.Count == 0)
                        {
                            _groupedContacts.Remove(keyValuePair);
                        }

                        return true;
                    }
                }
            }

            return false;
        }

        public bool ChangeCulture(string culture)
        {
            if (string.Equals(_currentCulture, culture))
            {
                return false;
            }

            if (_cultures.ContainsKey(culture))
            {
                _currentCulture = culture;
                Regroup();

                return true;
            }

            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<KeyValuePair<char, SortedSet<Contact>>> GetEnumerator()
        {
            foreach (var keyValue in _groupedContacts)
            {
                yield return keyValue;
            }
        }

        private void Init()
        {
            _cultures = _config.Cultures;
            _currentCulture = _config.CurrentCulture;
            _contactComparer = new ContactComparer(new CultureInfo(_currentCulture));
            _pattern = GetPattern();
            _groupedContacts = new SortedSet<KeyValuePair<char, SortedSet<Contact>>>(new GroupsComparer(_pattern));
        }

        private void Regroup()
        {
            var contacts = new List<Contact>();
            foreach (var keyValuePair in _groupedContacts)
            {
                foreach (var contact in keyValuePair.Value)
                {
                    contacts.Add(contact);
                }
            }

            _pattern = GetPattern();
            _groupedContacts = new SortedSet<KeyValuePair<char, SortedSet<Contact>>>(new GroupsComparer(_pattern));
            _contactComparer = new ContactComparer(new CultureInfo(_currentCulture));

            foreach (var contact in contacts)
            {
                Add(contact);
            }
        }

        private string GetPattern()
        {
            var alphabet = "abcdefghijklmnopqrstvwxyz";
            var numbers = "0123456789";
            _cultures.TryGetValue(_currentCulture, out alphabet);

            return $"{alphabet}{numbers}";
        }
    }
}
