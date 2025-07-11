// Papelaria.Web/Services/ApiProductService.cs
//using Papelaria.Business.Services;
//using Papelaria.Web; // Para IApiService
//using System.Threading.Tasks;
//using System.Linq;

//namespace Papelaria.Web.Services
//{
//    public class ApiProductService : IProductService
//    {
//        private readonly IApiService _apiService;

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
//    }
//}