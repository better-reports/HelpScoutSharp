using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HelpScoutSharp
{
    public interface IPage<TEntity>
    {
        Page page { get; }

        TEntity[] entities { get; }
    }
}
