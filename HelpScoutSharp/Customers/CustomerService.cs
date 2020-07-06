using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HelpScoutSharp
{
    public class CustomerService : ServiceBase
    {
        public CustomerService(string accessToken)
            : base(accessToken, "customers")
        {
        }


        public async Task<ListCustomersResponse> ListCustomersAsync(ListCustomersOptions options = null)
        {
            return await _client.GetAsync<ListCustomersOptions, ListCustomersResponse>(URI, options);
        }
    }
}
