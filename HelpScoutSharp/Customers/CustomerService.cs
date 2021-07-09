using Flurl;
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

        public async Task<Customer> GetAsync(long customerId)
        {
            return await _client.GetAsync<Customer>(new Url(_serviceUri).AppendPathSegment(customerId).ToUri());
        }

        public async Task<IPage<Customer>> ListAsync(ListCustomersOptions options = null)
        {
            return await _client.GetAsync<CustomerPage>(_serviceUri, options, url =>
            {
                //Taking control of datetime serialization because API expects a different formant that Flurl's default
                if (options?.modifiedSince != null)
                    url.SetQueryParam(nameof(ListCustomersOptions.modifiedSince), options.modifiedSince.Value.ToString("yyyy-MM-ddTHH:mm:ssZ"));
            });
        }
    }
}
