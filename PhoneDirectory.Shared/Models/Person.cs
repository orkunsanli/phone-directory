using System;
using System.Collections.Generic;

namespace PhoneDirectory.Shared.Models
{
    public class Person
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public List<ContactInformation> ContactInformation { get; set; } = new List<ContactInformation>();
    }
} 