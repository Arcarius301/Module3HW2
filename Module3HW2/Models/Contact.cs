using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3HW2.Models
{
    public class Contact : IEquatable<Contact>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }

        public string PhoneNumber { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Contact);
        }

        public bool Equals(Contact other)
        {
            return other != null &&
                   FullName == other.FullName &&
                   PhoneNumber == other.PhoneNumber;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FullName, PhoneNumber);
        }
    }
}
