using RestSharp;
using System.Web.Mvc;
using System.Threading.Tasks;
using SrodkiTrwale.Models.ViewModel;
using System.Text.Json;
using System.Collections.Generic;

namespace SrodkiTrwale.Controllers
{
    [Authorize]
    public class RaportController : Controller
    {
        public RaportController() {}
        
        public async Task<ViewResult> Index()
        {
            var resultJson = await SendRaportRequest();
            GetRaportModelView2 resultModel = JsonSerializer.Deserialize<GetRaportModelView2>(resultJson);


            RaportIndex response = new RaportIndex();
            RaportIndexUser singleR = null;
            foreach (var xItem in resultModel.users)
            {
                singleR = new RaportIndexUser();
                singleR.name = xItem.lastName + " " + xItem.firstName;
                singleR.fixedAssetsCount = xItem.fixedAssets.Count;
                response.Users.Add(singleR);
            }

            response.last30DaysFixedAssets = resultModel.assetsRegisteredInLast30Days;

            return View(response);
        }

        private async Task<string> SendRaportRequest()
        {
            var httpClient = new RestClient("https://localhost:44364/api");
            var request = new RestRequest("/Raport/GetRaports2", Method.Get);
            var response = await httpClient.ExecuteAsync(request);

            return response.Content;
        }
    }
}