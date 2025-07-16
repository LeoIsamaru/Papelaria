using Refit;
using Papelaria.Shared;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Papelaria.Web
{
    public interface IApiService
    {

        // CRUD básico
        [Get("/items")]
        Task<List<Papelaria.Shared.Item>> GetItemsAsync();


        [Get("/items/{id}")]
        Task<Papelaria.Shared.Item> GetItemAsync(int id);


        [Post("/items")]
        Task<HttpResponseMessage> AddItemAsync([Body] Shared.Item item);

        //[Post("/Additem")]
        //Task<HttpResponseMessage> AddItemAsync([Body] Shared.Item item);


        [Put("/items")]
        Task<HttpResponseMessage> UpdateItemAsync([Body] Shared.Item item);


        [Put("/items/{id}")]
        Task<HttpResponseMessage> DeleteItemAsync(int id);


        // GET brands, categories, suppliers
        [Get("/items/brands")]
        Task<List<Brand>> GetBrandsAsync();

        [Get("/items/categories")]
        Task<List<Category>> GetCategoriesAsync();

        [Get("/items/suppliers")]
        Task<List<Supplier>> GetSuppliersAsync();




        //para adicionar Brands, Category e Suppliers na BD
        [Post("/brands")]
        Task<HttpResponseMessage> AddBrandAsync([Body] Shared.Brand brand);

        [Post("/api/categories")]
        Task<HttpResponseMessage> AddCategoryAsync([Body] Shared.Category category);

        [Post("/api/suppliers")]
        Task<HttpResponseMessage> AddSupplierAsync([Body] Shared.Supplier supplier);


        // da aula do fernando já adaptado para o projeto, mas pode precisar ainda de correcçoes
        //[Get("/items")]
        //Task<List<Shared.Papelaria>> GetPatientsAsync();


        //[Get("/item/{id}")]
        //Task<Shared.Papelaria> GetPatientsAsync(int id);


        //[Post("/item")]
        //Task<HttpResponseMessage> AddPatientAsync([Body] Shared.Papelaria patient);


        //[Put("/item")]
        //Task<HttpResponseMessage> UpdatePatient([Body] Shared.Papelaria patient);


        //[Put("/items/{id}")]
        //Task<HttpResponseMessage> DeletePatientAsync(int id);


        // Endpoints específicos para dashboard
        //[Get("/dashboard/valor-total-stock")]
        //Task<decimal> GetValorTotalStockAsync();



        //[Get("/dashboard/top-categorias")]
        //Task<List<(string Categoria, int Quantidade)>> GetTopCategoriasAsync();
    }
}
