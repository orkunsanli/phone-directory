using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PhoneDirectory.Shared.Models;

namespace PhoneDirectory.Shared.Repositories
{
    public interface IPersonRepository : IRepository<Person>
    {
        Task<Person> GetPersonWithContactsAsync(Guid id);
        Task<IEnumerable<Person>> GetAllPersonsWithContactsAsync();
        Task<bool> AddContactToPersonAsync(Guid personId, ContactInformation contact);
        Task<bool> RemoveContactFromPersonAsync(Guid personId, Guid contactId);
    }
} 