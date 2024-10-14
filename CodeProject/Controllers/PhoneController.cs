using CodeProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace CodeProject.Controllers
{
    public class PhoneController : Controller
    {
        // GET: PhoneController
        public async Task<ActionResult> Index()
        {
            string apiUrl = "https://localhost:7014/api/user";

            List<Phone> phoneList = new List<Phone>();

            using (HttpClient client = new HttpClient())
            {   
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                var result = await response.Content.ReadAsStringAsync();
                phoneList = JsonConvert.DeserializeObject<List<Phone>>(result);
            }
                return View();
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
        public async Task<ActionResult> Create(Phone phone)
        {
            string apiUrl = "https://localhost:7014/api/user";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(phone), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(phone);
             
        }

        // GET: PhoneController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PhoneController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PhoneController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PhoneController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
