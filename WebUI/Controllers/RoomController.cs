using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using WebUI.Models;

namespace WebUI.Controllers
{
	public class RoomController : Controller
	{
		Uri baseAddress = new Uri("https://localhost:7175/api");
		private readonly HttpClient _client;

		public RoomController()
		{
			_client = new HttpClient();
			_client.BaseAddress = baseAddress;
		}
		public IActionResult Index()
		{
			HttpResponseMessage responseRoom = _client.GetAsync(_client.BaseAddress + "/rooms/getRoomList").Result;
			if (responseRoom.IsSuccessStatusCode)
			{
				string roomData = responseRoom.Content.ReadAsStringAsync().Result;
				var roomDataList = JsonConvert.DeserializeObject<List<Room>>(roomData);
				var buildingDataList = GetBuildingList();
				var result = (from r in roomDataList
							  from b in buildingDataList
							  where r.BuildingId == b.BuildingId
							  select new RoomViewModel() { RoomId = r.RoomId, RoomName = r.RoomName, BuildingId = b.BuildingId, BuildingName = b.BuildingName });
				List<RoomViewModel> roomList = result.ToList();
				return View(roomList);
			}
			return View();
		}


		[HttpGet]
		public IActionResult Create()
		{
			HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/buildings/getBuildingList").Result;
			if (response.IsSuccessStatusCode)
			{
				string data = response.Content.ReadAsStringAsync().Result;
				List<BuildingViewModel> buildingList = GetBuildingList();
                ViewBag.BuildingNameList = new SelectList(buildingList, "BuildingId", "BuildingName");
            }
			return View();
		}

		[HttpPost]
		public IActionResult Create(RoomViewModel model)
		{
            var postTask = _client.PostAsJsonAsync<RoomViewModel>(_client.BaseAddress + "/rooms/addRoom", model);
            postTask.Wait();
            var result = postTask.Result;
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
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/rooms/getByRoomId?roomId=" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string roomData = response.Content.ReadAsStringAsync().Result;
                RoomViewModel model = JsonConvert.DeserializeObject<RoomViewModel>(roomData);
                return View(model);
            }
            return View();
		}

		[HttpPost]
		public IActionResult Edit(RoomViewModel model)
		{
			var postTask = _client.PostAsJsonAsync<RoomViewModel>(_client.BaseAddress + "/rooms/updateRoom", model);
			postTask.Wait();
			var result = postTask.Result;
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
			HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/rooms/getByRoomId?roomId=" + id).Result;
			if (response.IsSuccessStatusCode)
			{
				string data = response.Content.ReadAsStringAsync().Result;
				RoomViewModel model = JsonConvert.DeserializeObject<RoomViewModel>(data);
				var deleteReponse = _client.PostAsJsonAsync<RoomViewModel>(_client.BaseAddress + "/rooms/deleteRoom", model);
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
