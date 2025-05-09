﻿using Mango.Services.ProductAPI.Models.DTO;

namespace Mango.Services.ProductAPI.Repository
{
    public interface IProductRepository
    {
        public Task<IEnumerable<ProductDto>> GetProducts();
        Task<ProductDto> GetProductById(int id);
        Task<ProductDto> CreateUpdateProduct(ProductDto productDto);
        Task<bool> DeleteProduct(int id);
    }
}
