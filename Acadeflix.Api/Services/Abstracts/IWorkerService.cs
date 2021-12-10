using System.Collections.Generic;
using System.Threading.Tasks;

namespace Acadeflix.Api.Services.Abstracts
{
    public interface IWorkerService<T>
    {
        Task<List<T>> Get();
        Task<T> Get(int id);
    }
}
