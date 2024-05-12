using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class BuildingController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7175/api");
        private readonly HttpClient _client;

        public BuildingController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        public IActionResult Index()
        {     
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/buildings/getBuildingList").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
				List<BuildingViewModel> buildingList = JsonConvert.DeserializeObject<List<BuildingViewModel>>(data);
                return View(buildingList);
            }
            return View();

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BuildingViewModel model)
        {
            var response = _client.PostAsJsonAsync<BuildingViewModel>(_client.BaseAddress + "/buildings/addBuilding", model);
            response.Wait();
            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError(string.Empty, "Hatalı işlem.");

            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/buildings/getByBuildingId?buildingId=" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                BuildingViewModel model = JsonConvert.DeserializeObject<BuildingViewModel>(data);
                return View(model);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Edit(BuildingViewModel model)
        {
            var response = _client.PostAsJsonAsync<BuildingViewModel>(_client.BaseAddress + "/buildings/updateBuilding", model);
            response.Wait();
            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError(string.Empty, "Hatalı işlem.");
            return View(model);
        }


		[HttpGet]
		public IActionResult Delete(int id)
		{
			HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/buildings/getByBuildingId?buildingId=" + id).Result;
			if (response.IsSuccessStatusCode)
			{
				string data = response.Content.ReadAsStringAsync().Result;
				BuildingViewModel model = JsonConvert.DeserializeObject<BuildingViewModel>(data);
				var deleteReponse = _client.PostAsJsonAsync<BuildingViewModel>(_client.BaseAddress + "/buildings/deleteBuilding", model);
				deleteReponse.Wait();
				var result = deleteReponse.Result;
				if (result.IsSuccessStatusCode)
				{
					return RedirectToAction("Index");
				}
			
			}
            return View();
		}
	}
}
