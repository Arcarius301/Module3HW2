using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Module3HW2.Models;

namespace Module3HW2
{
    public class ContactComparer : IComparer<Contact>
    {
        private readonly CultureInfo _culture;
        private readonly StringComparer _stringComparer;

        public ContactComparer(CultureInfo culture)
        {
            _culture = culture;
            _stringComparer = StringComparer.Create(_culture, true);
        }

        public int Compare(Contact x, Contact y)
        {
            if (_stringComparer.Compare(x.FullName, y.FullName) == 1)
            {
                return 1;
            }
            else if (_stringComparer.Compare(x.FullName, y.FullName) == -1)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
