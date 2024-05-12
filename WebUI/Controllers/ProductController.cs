using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class ProductController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7175/api");
        private readonly HttpClient _client;

        public ProductController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }
        public IActionResult Index()
        {
            List<ProductViewModel> productList = new List<ProductViewModel>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress+ "/products/getProductList").Result;
            if(response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                productList = JsonConvert.DeserializeObject<List<ProductViewModel>>(data);
            }
            return View(productList);
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductViewModel model)
        {
            var postTask = _client.PostAsJsonAsync<ProductViewModel>(_client.BaseAddress + "/products/addProduct", model);
            postTask.Wait();

            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError(string.Empty, "Ekleme gerçekleşemedi.");

            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ProductViewModel model = new ProductViewModel();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/products/getByProductId?productId=" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                model = JsonConvert.DeserializeObject<ProductViewModel>(data);
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(ProductViewModel model)
        {
            var postTask = _client.PostAsJsonAsync<ProductViewModel>(_client.BaseAddress + "/products/updateProduct", model);
            postTask.Wait();

            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError(string.Empty, "Güncelleme gerçekleşmedi.");

            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/products/getByProductId?productId=" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                ProductViewModel model = JsonConvert.DeserializeObject<ProductViewModel>(data);
                var deleteReponse = _client.PostAsJsonAsync<ProductViewModel>(_client.BaseAddress + "/products/deleteProduct", model);
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
