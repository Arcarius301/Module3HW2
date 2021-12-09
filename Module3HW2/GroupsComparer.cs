using System.Collections.Generic;
using Module3HW2.Models;

namespace Module3HW2
{
    public class GroupsComparer : IComparer<KeyValuePair<char, SortedSet<Contact>>>
    {
        private string _pattern;
        public GroupsComparer(string pattern)
        {
            _pattern = pattern;
        }

        public int Compare(KeyValuePair<char, SortedSet<Contact>> x, KeyValuePair<char, SortedSet<Contact>> y)
        {
            if (GetIndex(x.Key) > GetIndex(y.Key))
            {
                return 1;
            }
            else if (GetIndex(x.Key) < GetIndex(y.Key))
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        private int GetIndex(char letter)
        {
            var index = _pattern.IndexOf(letter);

            if (index == -1)
            {
                return _pattern.Length + 1;
            }
            else
            {
                return index;
            }
        }
    }
}
