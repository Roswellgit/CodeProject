using CodeProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text;
using Newtonsoft.Json;
using System.Reflection;

namespace CodeProject.Controllers
{
    public class PhoneController : Controller
    {
        // GET: PhoneController
        public async Task<ActionResult> Index()
        {
            string apiUrl = "https://localhost:7082/api/user/View";

            List<UserPhone> phoneList = new List<UserPhone>();

            using (HttpClient client = new HttpClient())
            {   
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                var result = await response.Content.ReadAsStringAsync();
                phoneList = JsonConvert.DeserializeObject<List<UserPhone>>(result);
            }
                return View(phoneList);
        }

        // GET: PhoneController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PhoneController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PhoneController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(UserPhone userphone)
        {
            string apiUrl = "https://localhost:7082/api/user/Create";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(userphone), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(userphone);
             
        }

        // GET: PhoneController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PhoneController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UserPhone userphone)
        {
            string apiUrl = "https://localhost:7082/api/user/Update";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(userphone), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PatchAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(userphone);
        }

        // GET: PhoneController/Delete/5
        public ActionResult Delete(int id)
        {
        
            return View();
        }

        // POST: PhoneController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(UserPhone userPhone)
        {
            string apiUrl = "https://localhost:7082/api/user/Remove";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(userPhone), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.DeleteAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(userPhone);
        }
    }
}
