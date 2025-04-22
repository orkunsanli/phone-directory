using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhoneDirectory.Shared.DTOs;
using PhoneDirectory.Shared.Models;
using PhoneDirectory.Shared.Repositories;

namespace PhoneDirectory.PersonService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;

        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonDTO>>> GetAll()
        {
            var persons = await _personRepository.GetAllPersonsWithContactsAsync();
            return Ok(MapToDTOs(persons));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonDTO>> GetById(Guid id)
        {
            var person = await _personRepository.GetPersonWithContactsAsync(id);
            if (person == null)
                return NotFound();

            return Ok(MapToDTO(person));
        }

        [HttpPost]
        public async Task<ActionResult<PersonDTO>> Create(CreatePersonDTO dto)
        {
            var person = new Person
            {
                Id = Guid.NewGuid(),
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Company = dto.Company
            };

            await _personRepository.AddAsync(person);
            await _personRepository.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = person.Id }, MapToDTO(person));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdatePersonDTO dto)
        {
            var person = await _personRepository.GetByIdAsync(id);
            if (person == null)
                return NotFound();

            person.FirstName = dto.FirstName;
            person.LastName = dto.LastName;
            person.Company = dto.Company;

            _personRepository.Update(person);
            await _personRepository.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var person = await _personRepository.GetByIdAsync(id);
            if (person == null)
                return NotFound();

            _personRepository.Remove(person);
            await _personRepository.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost("{personId}/contacts")]
        public async Task<ActionResult<ContactInformationDTO>> AddContact(Guid personId, CreateContactInformationDTO dto)
        {
            var contact = new ContactInformation
            {
                Id = Guid.NewGuid(),
                Type = dto.Type,
                Content = dto.Content
            };

            var success = await _personRepository.AddContactToPersonAsync(personId, contact);
            if (!success)
                return NotFound();

            return CreatedAtAction(nameof(GetById), new { id = personId }, MapToDTO(contact));
        }

        [HttpDelete("{personId}/contacts/{contactId}")]
        public async Task<IActionResult> RemoveContact(Guid personId, Guid contactId)
        {
            var success = await _personRepository.RemoveContactFromPersonAsync(personId, contactId);
            if (!success)
                return NotFound();

            return NoContent();
        }

        private static PersonDTO MapToDTO(Person person)
        {
            return new PersonDTO
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Company = person.Company,
                ContactInformation = person.ContactInformation.Select(MapToDTO).ToList()
            };
        }

        private static IEnumerable<PersonDTO> MapToDTOs(IEnumerable<Person> persons)
        {
            return persons.Select(MapToDTO);
        }

        private static ContactInformationDTO MapToDTO(ContactInformation contact)
        {
            return new ContactInformationDTO
            {
                Id = contact.Id,
                PersonId = contact.PersonId,
                Type = contact.Type,
                Content = contact.Content
            };
        }
    }
} 