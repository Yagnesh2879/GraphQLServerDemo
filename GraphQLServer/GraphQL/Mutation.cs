using GraphQLServer.Models;

namespace GraphQLServer.GraphQL
{
    public class Mutation
    {
        public async Task<Customer> AddCustomer(Customer customer, AppDbContext context)
        {
            context.Customers.Add(customer);
            await context.SaveChangesAsync();
            return customer;
        }
    }
}
