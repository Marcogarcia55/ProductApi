using ProductApi.Models;
using ProductApi.Repositories;

namespace ProductApi.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public async Task<int> AddAsync(Product product)
        {
            return await _productRepository.AddAsync(product);
        }

        public async Task<int> UpdateAsync(Product product)
        {
            return await _productRepository.UpdateAsync(product);
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _productRepository.DeleteAsync(id);
        }
    }
}
