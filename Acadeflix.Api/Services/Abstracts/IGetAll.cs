using System.Collections.Generic;
using System.Threading.Tasks;

namespace Acadeflix.Api.Services.Abstracts
{
    public interface IGetAll<T>
    {
        Task<List<T>> Get();
    }
}
