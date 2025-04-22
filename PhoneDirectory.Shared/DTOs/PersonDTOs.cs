using System;
using System.Collections.Generic;

namespace PhoneDirectory.Shared.DTOs
{
    public class PersonDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public List<ContactInformationDTO> ContactInformation { get; set; } = new List<ContactInformationDTO>();
    }

    public class CreatePersonDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
    }

    public class UpdatePersonDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
    }

    public class ContactInformationDTO
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public ContactType Type { get; set; }
        public string Content { get; set; }
    }

    public class CreateContactInformationDTO
    {
        public ContactType Type { get; set; }
        public string Content { get; set; }
    }
} 