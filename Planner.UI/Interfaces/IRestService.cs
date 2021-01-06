using Planner.Shared.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.UI.Interfaces
{
    public interface IRestService<T> 
        where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetAsync();
        Task<T> PostAsync(T model);
        Task<ResponseResultEnum> PutAsync();
        Task<ResponseResultEnum> DeleteAsync();
    }
}
