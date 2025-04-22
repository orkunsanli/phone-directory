using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PhoneDirectory.Shared.Data;
using PhoneDirectory.Shared.Models;

namespace PhoneDirectory.Shared.Repositories
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(PhoneDirectoryDbContext context) : base(context)
        {
        }

        public async Task<Person> GetPersonWithContactsAsync(Guid id)
        {
            return await _context.Persons
                .Include(p => p.ContactInformation)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Person>> GetAllPersonsWithContactsAsync()
        {
            return await _context.Persons
                .Include(p => p.ContactInformation)
                .ToListAsync();
        }

        public async Task<bool> AddContactToPersonAsync(Guid personId, ContactInformation contact)
        {
            var person = await GetPersonWithContactsAsync(personId);
            if (person == null)
                return false;

            contact.PersonId = personId;
            person.ContactInformation.Add(contact);
            return await SaveChangesAsync();
        }

        public async Task<bool> RemoveContactFromPersonAsync(Guid personId, Guid contactId)
        {
            var person = await GetPersonWithContactsAsync(personId);
            if (person == null)
                return false;

            var contact = person.ContactInformation.FirstOrDefault(c => c.Id == contactId);
            if (contact == null)
                return false;

            person.ContactInformation.Remove(contact);
            return await SaveChangesAsync();
        }
    }
} 