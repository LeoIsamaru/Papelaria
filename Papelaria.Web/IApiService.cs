using Refit;
//using Papelaria.Shared;
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





        //[Get("/item/{id}")]
        //Task<Shared.Papelaria> GetPatientsAsync(int id);


        [Post("/items")]
        Task<HttpResponseMessage> AddItemAsync([Body] Shared.Item item);


        [Put("/items")]
        Task<HttpResponseMessage> UpdateItemAsync([Body] Shared.Item item);


        [Put("/items/{id}")]
        Task<HttpResponseMessage> DeleteItemAsync(int id);





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
