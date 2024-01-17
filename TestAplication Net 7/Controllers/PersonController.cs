using Domain.Models;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using TestAplication_Net_7.Models.DTO;

namespace TestAplication_Net_7.Controllers
{
    [ApiController]
    [Route("api/person")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;

        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Person>>> GetPersons()
        {
            var persons = await _personRepository.GetAsync();
            return Ok(persons);
        }

        [HttpPost]
        public async Task<ActionResult<Person>> CreatePerson([FromBody] PersonDTO person)
        {
            var Person = new Person(person.LastName,person.FirstName);
            var createdPerson = await _personRepository.AddAsync(Person);
            return CreatedAtAction(nameof(GetPersons), createdPerson);
        }

        [HttpPut]
        public async Task<ActionResult<Person>> UpdatePerson([FromBody] Person person)
        {
            var existingPerson = await _personRepository.UpdateAsync(person);

            if (existingPerson == null)
            {
                return NotFound();
            }

            existingPerson.UpdateFirstName(person.FirstName);
            existingPerson.UpdateLastName(person.LastName);

            var updatedPerson = await _personRepository.UpdateAsync(existingPerson);
            return Ok(updatedPerson);
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeletePerson(Guid id)
        {
            var result = await _personRepository.DeleteAsync(id);

            if (result)
            {
                return Ok(true);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
