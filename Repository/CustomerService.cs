using Liskov_Substitution_Principle.DataTransferObject;

namespace Liskov_Substitution_Principle.Repository
{
    public class CustomerService
    {
        private readonly IEnumerable<ICustomerRepository> _customerRepositories;

        public CustomerService(IEnumerable<ICustomerRepository> customerRepositories) 
        {
            _customerRepositories = customerRepositories;
        }

        public async Task<IEnumerable<Customer>> GetCustomersByLastNameAsync(string lastName)
        {
            var tasks = _customerRepositories.Select(repo => repo.GetCustomersByLastNameAsync(lastName));
            var results = await Task.WhenAll(tasks);
                return results.SelectMany(r => r);
        }
    }
}
