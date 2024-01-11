using E_commerce1.Data;
using E_commerce1.Models;
using E_commerce1.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_commerce1.Controllers
{
    public class CategorieController1 : Controller
    {
        private MVCDemoDbContext mvcDemoDbContext;


        public CategorieController1(MVCDemoDbContext mvcDemoDbContext)
        {
            this.mvcDemoDbContext = mvcDemoDbContext;
        }




        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await mvcDemoDbContext.categorie.ToListAsync();
            return View(categories);
        }



        //Categories
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Add(AddCategorieViewModel addCategorieRequest)
        {
            var categorie = new Categorie()
            {
                idCategorie = addCategorieRequest.idCategorie,
                nomCategorie = addCategorieRequest.nomCategorie,
            };

            mvcDemoDbContext.categorie.Add(categorie);
            await mvcDemoDbContext.SaveChangesAsync();

            var categories = mvcDemoDbContext.categorie.Where
                (p => p.idCategorie == categorie.idCategorie);

            return RedirectToAction("Index");

        }

        [HttpGet]
        public async Task<IActionResult> View(int id)
        {
            var categorie = await mvcDemoDbContext.categorie.FirstOrDefaultAsync(x => x.idCategorie == id);
            if (categorie != null)
            {
                var viewModel = new UpdateCategorieViewModel()
                {
                    idCategorie = categorie.idCategorie,
                    nomCategorie = categorie.nomCategorie,

                };
                return await Task.Run(()=>View("View", viewModel));
            }

            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> View(UpdateCategorieViewModel model)
        {
            var categorie = await mvcDemoDbContext.categorie.FindAsync(model.idCategorie);
            if (categorie != null)
            {
                categorie.nomCategorie = model.nomCategorie;


                await mvcDemoDbContext.SaveChangesAsync();
                return RedirectToAction("Index");

            }
            return RedirectToAction("Index");

        }


        //delete

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateCategorieViewModel model)
        {
            var categorie = await mvcDemoDbContext.categorie.FindAsync(model.idCategorie);
            if (categorie != null)
            {
                mvcDemoDbContext.categorie.Remove(categorie);
                await mvcDemoDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }


    }
}
