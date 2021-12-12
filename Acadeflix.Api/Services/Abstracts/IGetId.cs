using System.Collections.Generic;
using System.Threading.Tasks;

namespace Acadeflix.Api.Services.Abstracts
{
    public interface IGetId<T>
    {
        Task<T> Get(int id);
    }
}
