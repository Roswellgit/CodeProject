using CodeProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text;
using Newtonsoft.Json;

using System.Reflection;
namespace CodeProject.Controllers
{
    public class CatController : Controller
    {
        // GET: CatController
        public async Task<ActionResult> Index()
        {
            string apiUrl = "https://cat-fact.herokuapp.com/#/cat/facts";

            List<Cats> quo = new List<Cats>();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                var result = await response.Content.ReadAsStringAsync();
                quo = JsonConvert.DeserializeObject<List<Cats>>(result);
            }
            return View(quo);
        }
        // GET: CatController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CatController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CatController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: CatController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CatController/Edit/5
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

        // GET: CatController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CatController/Delete/5
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
