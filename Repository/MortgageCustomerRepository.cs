﻿using Liskov_Substitution_Principle.DatabaseContext;
using Liskov_Substitution_Principle.DataTransferObject;
using Microsoft.EntityFrameworkCore;

namespace Liskov_Substitution_Principle.Repository
{
    public class MortgageCustomerRepository : ICustomerRepository
    {
        private readonly MortgageDbContext _context;

        public MortgageCustomerRepository(MortgageDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetCustomersByLastNameAsync(string lastName)
        {
            return await _context.Customers
                .Where(c => c.LastName == lastName)
                .ToListAsync();
        }
    }
}
