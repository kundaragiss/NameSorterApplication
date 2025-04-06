using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Name
    {
        public string FirstName { get; }
        public string LastName { get; }

        public Name(string fullName)
        {
            var parts = fullName.Split(' ');
            LastName = parts[^1]; // Last element
            FirstName = string.Join(" ", parts[..^1]); // Remaining elements
        }

        public override string ToString() => $"{FirstName} {LastName}";

    }
}
