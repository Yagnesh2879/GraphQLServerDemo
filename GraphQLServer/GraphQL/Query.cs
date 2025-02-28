using GraphQLServer.Models;
using HotChocolate;
using HotChocolate.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace GraphQLServer.GraphQL
{
    public class Query
    {
        
        //[UseDbContext(typeof(AppDbContext))]
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Customer> GetCustomers(AppDbContext context, string firstNameContains = "")
        {

            //return context.Customers;

            var customers = context.Customers.AsNoTracking()
                .Include(p => p.Addresses)
                .Include(q => q.PaymentInfos)
                .Include(r => r.BusinessInfo);
            if (firstNameContains == string.Empty)
                return customers;
            else
            {
                return customers.Where(o => o.FirstName.Contains(firstNameContains));
            }

            //return context.Customers
            //    .Join(context.CustomerAddresses, x => new {customerCustID= x.CustomerId }, y => new{addressCustID= y.CustomerId }, (x, y) => new(x, y));
        }
    }
}
