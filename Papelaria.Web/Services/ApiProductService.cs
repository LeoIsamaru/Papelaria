using Papelaria.Shared; // TODO: Confirmar se este é o namespace certo onde estão Brand e Category
using Refit;
using System.Net.Http.Json;

namespace Papelaria.Web.Services
{
    public class ApiProductService : IApiService
    {
        private readonly IApiService? _apiService;

        //        public ApiProductService(IApiService apiService)
        //        {
        //            _apiService = apiService;
        //        }

        //        public async Task<decimal> GetValorTotalStockAsync()
        //        {
        //            var items = await _apiService.GetItemsAsync();
        //            return items.Where(i => !i.IsDeleted)
        //                      .Sum(i => i.QtyStock * (decimal)i.BuyingFromSupplierPrice);
        //        }

        //        // Implementar outros métodos...

        private readonly HttpClient _httpClient;

        public ApiProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        //public async Task<HttpResponseMessage> AddBrandAsync(Brand brand)
        //{
        //    var response = await _httpClient.PostAsJsonAsync("/api/brands", brand);
        //    return response;
        //}


        public async Task<HttpResponseMessage> AddBrandAsync(Brand brand)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/brands", brand);
            return response;
        }



        public async Task AddCategoryAsync(Category category)
        {
            var response = await _httpClient.PostAsJsonAsync("/category", category);
            response.EnsureSuccessStatusCode();
        }

        public Task<HttpResponseMessage> AddItemAsync([Body] Item item)
        {
            throw new NotImplementedException();
        }

        public async Task AddSupplierAsync(Supplier supplier)
        {
            var response = await _httpClient.PostAsJsonAsync("/supplier", supplier);
            response.EnsureSuccessStatusCode();
        }




        //Visual studio sugeriu isto abaixo para corrigir um erro:
        public Task<HttpResponseMessage> DeleteItemAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Brand>> GetBrandsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Category>> GetCategoriesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Item> GetItemAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Item>> GetItemsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Supplier>> GetSuppliersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> UpdateItemAsync([Body] Item item)
        {
            throw new NotImplementedException();
        }

        //Task<HttpResponseMessage> IApiService.AddBrandAsync(Brand brand)
        //{
        //    throw new NotImplementedException();
        //}

        Task<HttpResponseMessage> IApiService.AddCategoryAsync(Category category)
        {
            throw new NotImplementedException();
        }

        Task<HttpResponseMessage> IApiService.AddSupplierAsync(Supplier supplier)
        {
            throw new NotImplementedException();
        }


    }

}





//public class ApiProductService : IApiService
//{
//    private readonly HttpClient _httpClient;

//    public ApiProductService(HttpClient httpClient)
//    {
//        _httpClient = httpClient;
//    }
