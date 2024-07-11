using Liskov_Substitution_Principle.DataTransferObject;

namespace Liskov_Substitution_Principle.Repository
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetCustomersByLastNameAsync(string lastName);
    }
}
