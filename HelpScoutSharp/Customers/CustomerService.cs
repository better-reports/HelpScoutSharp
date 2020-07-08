using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HelpScoutSharp
{
    public class CustomerService : ServiceBase, IListableService<Customer, ListCustomersOptions>
    {
        public CustomerService(string accessToken)
            : base(accessToken, "customers")
        {
        }


        public async Task<IPage<Customer>> ListAsync(ListCustomersOptions options = null)
        {
            return await _client.GetAsync<CustomerPage>(_serviceUri, options);
        }
    }
}
