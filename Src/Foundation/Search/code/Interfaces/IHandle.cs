using Sitecore8Helix.Foundation.Search.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sitecore8Helix.Foundation.Search.Interfaces
{
    public interface IHandle<in TQuery, in TDocType, out TResult> where TQuery : IQuery where TResult : SearchResult<TDocType>
    {
        TResult Handle(TQuery query);
    }
}
