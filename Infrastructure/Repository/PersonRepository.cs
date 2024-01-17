using Domain.Models;
using Infrastructure.DataBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class PersonRepository: IPersonRepository
    {
        private readonly ApplicationConext _context;

        public PersonRepository(ApplicationConext context)
        {
            _context = context;
        }

        public async Task<Person> AddAsync(Person person)
        {
            await _context.Persons.AddAsync(person);
            await SaveAsync();
            return person;
        }

        public async Task<bool> DeleteAsync(Guid guid)
        {
            var person = await _context.Persons.FirstOrDefaultAsync(x => x.Id == guid);
            if (person != null)
            {
                 _context.Remove(person);
                await SaveAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<List<Person>> GetAsync()
        {
            return await _context.Persons.ToListAsync();
        }

        public async Task<Person> UpdateAsync(Person person)
        {
            var personContext = await _context.Persons.FirstOrDefaultAsync(x => x.Id == person.Id);
            personContext.UpdateLastName(person.LastName);
            personContext.UpdateFirstName(person.FirstName);
            await SaveAsync();
            return personContext;
        }
        private async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
