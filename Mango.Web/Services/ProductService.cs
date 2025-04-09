using Mango.Web.Models;
using Mango.Web.Services.IServices;

namespace Mango.Web.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductService(IHttpClientFactory httpClientFactory) :base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public ResponseDto ResponseModel { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public async Task<T> CreateProductProductAsync<T>(ProductDto productDto)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = Const.ApiType.POST,
                Data = productDto,
                Url = Const.ProductAPIBase + "/api/products",
                AccessToken = ""
            });
        }

        public async Task<T> DeleteProductAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = Const.ApiType.DELETE,
                Url = Const.ProductAPIBase + "/api/products" + id,
                AccessToken = ""
            });
        }

        public async Task<T> GetAllProductAsync<T>()
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = Const.ApiType.GET,
                Url = Const.ProductAPIBase + "/api/products",
                AccessToken = ""
            });
        }

        public async Task<T> GetProductByIdAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = Const.ApiType.GET,
                Url = Const.ProductAPIBase + "/api/products/" + id,
                AccessToken = ""
            });
        }

        public async Task<T> UpdateProductProductAsync<T>(ProductDto productDto)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = Const.ApiType.PUT,
                Data = productDto,
                Url = Const.ProductAPIBase + "/api/products",
                AccessToken = ""
            });
        }
    }
}
