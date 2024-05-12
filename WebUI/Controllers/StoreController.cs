using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class StoreController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7175/api");
        private readonly HttpClient _client;

        public StoreController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        public IActionResult Index()
        {
            List<StoreViewModel> storeList = new List<StoreViewModel>();
            HttpResponseMessage responseRoom = _client.GetAsync(_client.BaseAddress + "/stores/getStoreList").Result;
            if (responseRoom.IsSuccessStatusCode)
            {
                string storeData = responseRoom.Content.ReadAsStringAsync().Result;
                var storeDataList = JsonConvert.DeserializeObject<List<StoreViewModel>>(storeData);
                var buildingDataList = GetBuildingList();
                var result = (from s in storeDataList
                              from b in buildingDataList
                              where s.BuildingId == b.BuildingId
                              select new StoreViewModel() { StoreId = s.StoreId, StoreName = s.StoreName, BuildingId = b.BuildingId, BuildingName = b.BuildingName });

                storeList = result.ToList();
            }
            return View(storeList);

        }

        [HttpGet]
        public IActionResult Create()
        {
			ViewBag.BuildingNameList = new SelectList(GetBuildingList(), "BuildingId", "BuildingName");
			return View();
        }

        [HttpPost]
        public IActionResult Create(StoreViewModel model)
        {
            var response = _client.PostAsJsonAsync<StoreViewModel>(_client.BaseAddress + "/stores/addStore", model);
            response.Wait();
            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError(string.Empty, "Hatalı işlem.");
			ViewBag.BuildingNameList = new SelectList(GetBuildingList(), "BuildingId", "BuildingName");
			return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.BuildingNameList = new SelectList(GetBuildingList(), "BuildingId", "BuildingName");
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/stores/getByStoreId?storeId=" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                StoreViewModel model = JsonConvert.DeserializeObject<StoreViewModel>(data);
                return View(model);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Edit(StoreViewModel model)
        {
            var response = _client.PostAsJsonAsync<StoreViewModel>(_client.BaseAddress + "/stores/updateStore", model);
            response.Wait();
            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError(string.Empty, "Hatalı işlem.");
			ViewBag.BuildingNameList = new SelectList(GetBuildingList(), "BuildingId", "BuildingName");
			return View(model);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/stores/getByStoreId?storeId=" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                StoreViewModel model = JsonConvert.DeserializeObject<StoreViewModel>(data);
                var deleteReponse = _client.PostAsJsonAsync<StoreViewModel>(_client.BaseAddress + "/stores/deleteStore", model);
                deleteReponse.Wait();
                var result = deleteReponse.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

            }
            return View();
        }

		private List<BuildingViewModel> GetBuildingList()
		{
			List<BuildingViewModel> buildingList = new List<BuildingViewModel>();
			HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/buildings/getBuildingList").Result;
			if (response.IsSuccessStatusCode)
			{
				string data = response.Content.ReadAsStringAsync().Result;
				buildingList = JsonConvert.DeserializeObject<List<BuildingViewModel>>(data);
			}
			return buildingList;
		}
	}
}
