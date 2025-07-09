using Refit;
//using Papelaria.Shared;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Papelaria.Web
{
    public interface IApiService
    {


        [Get("/items")]
        Task<List<Papelaria.Shared.Item>> GetItemsAsync();

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


    }
}
