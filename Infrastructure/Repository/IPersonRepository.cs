using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public interface IPersonRepository
    {
        Task<Person> AddAsync(Person person);
        Task<bool> DeleteAsync(Guid guid);
        Task<List<Person>> GetAsync();
        Task<Person> UpdateAsync(Person person);
    }
}
