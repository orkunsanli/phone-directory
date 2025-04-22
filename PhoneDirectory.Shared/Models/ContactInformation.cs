using System;

namespace PhoneDirectory.Shared.Models
{
    public class ContactInformation
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public ContactType Type { get; set; }
        public string Content { get; set; }
    }

    public enum ContactType
    {
        PhoneNumber,
        Email,
        Location
    }
} 