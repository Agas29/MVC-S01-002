using dotnet_mvc_first_app.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_mvc_first_app.Controllers
{
    public class KategoriController : Controller
    {
        private static List<Kategori> _kategoriList = new List<Kategori>
        {
            new Kategori { Id = 1, Tipe = "income", Nama = "Gaji", Deskripsi = "Pendapatan gaji bulanan", Status = "active" },
            new Kategori { Id = 2, Tipe = "expense", Nama = "Makan", Deskripsi = "Biaya makan", Status = "active" }
        };
        public IActionResult Index()
        {
            return View(_kategoriList);
        }

        public IActionResult Create()
        {
            return View();
        }

        // 3. PROSES TAMBAH (POST)
        [HttpPost]
        public IActionResult Create(Kategori model)
        {
            if (ModelState.IsValid)
            {
                model.Id = _kategoriList.Any() ? _kategoriList.Max(x => x.Id) + 1 : 1;
                _kategoriList.Add(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // 4. FORM EDIT (GET)
        public IActionResult Edit(int id)
        {
            var data = _kategoriList.FirstOrDefault(x => x.Id == id);
            if (data == null) return NotFound();
            return View(data);
        }

        // 5. PROSES EDIT (POST)
        [HttpPost]
        public IActionResult Edit(Kategori model)
        {
            if (ModelState.IsValid)
            {
                var data = _kategoriList.FirstOrDefault(x => x.Id == model.Id);
                if (data != null)
                {
                    data.Tipe = model.Tipe;
                    data.Nama = model.Nama;
                    data.Deskripsi = model.Deskripsi;
                    data.Status = model.Status;
                }
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // 6. LIHAT DETAIL
        public IActionResult Details(int id)
        {
            var data = _kategoriList.FirstOrDefault(x => x.Id == id);
            if (data == null) return NotFound();
            return View(data);
        }

        // 7. HAPUS DATA
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var data = _kategoriList.FirstOrDefault(x => x.Id == id);
            if (data != null)
            {
                _kategoriList.Remove(data);
            }
            return RedirectToAction("Index");
        }
    }
}
