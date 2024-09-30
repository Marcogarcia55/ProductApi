using ProductApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductApi.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task<int> AddAsync(Product product);
        Task<int> UpdateAsync(Product product);
        Task<int> DeleteAsync(int id);
        
    }
}
