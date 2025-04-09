using Mango.Web.Models;

namespace Mango.Web.Services.IServices
{
    public interface IProductService: IBaseService
    {
        Task<T> GetAllProductAsync<T>();
        Task<T> GetProductByIdAsync<T>(int id);

        Task<T> CreateProductProductAsync<T>(ProductDto productDto);
        Task<T> UpdateProductProductAsync<T>(ProductDto productDto);

        Task<T> DeleteProductAsync<T>(int id);

    }
}
