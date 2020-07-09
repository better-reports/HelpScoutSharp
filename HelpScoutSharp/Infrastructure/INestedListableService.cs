using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HelpScoutSharp
{
    public interface INestedListableService<TNestedEntity, TNestedListOptions>
        where TNestedEntity : IHasId
        where TNestedListOptions : ListOptions, new()
    {
        Task<IPage<TNestedEntity>> ListAsync(long parentId, TNestedListOptions listOptions = null);
    }
}
