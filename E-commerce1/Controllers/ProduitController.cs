using E_commerce1.Data;
using E_commerce1.Models;
using E_commerce1.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_commerce1.Controllers
{
    public class ProduitController : Controller
    {
        private MVCDemoDbContext mvcDemoDbContext;

        public ProduitController(MVCDemoDbContext mvcDemoDbContext)
        {
            this.mvcDemoDbContext = mvcDemoDbContext;



        }




        //Produits
        // [HttpGet] ==> identifier une action de contrôleur
        //qui peut être appelée à l'aide de la méthode HTTP GET

        [HttpGet]
        public async Task <IActionResult> Index()
        {
            var produits = await mvcDemoDbContext.produit.ToListAsync();
            return View(produits);
        }


        //Produit/Add 
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]

        public async Task <IActionResult> Add(AddProduitViewModel addProduitRequest)
        {
            var produit = new Produit()
            {
                idProduit = addProduitRequest.idProduit,
                nomProduit = addProduitRequest.nomProduit,
                prix = 12.5M,
                reference = addProduitRequest.reference,
                description = addProduitRequest.description,
               // idUtilisateur = 11,
                //idStock = 12,
                //idCategorie = 33

            };

            Console.WriteLine("The password1 = " + produit);
             mvcDemoDbContext.produit.Add(produit);
            Console.WriteLine("The password2 = " + produit);
            await mvcDemoDbContext.SaveChangesAsync();
            Console.WriteLine("The password3 = " + produit);

            var produits = mvcDemoDbContext.produit.Where(p => p.idProduit == produit.idProduit);





            return RedirectToAction("Index");
             
        }



        //Produit/View : 

        // pour afficher les données dans le formulaire 
        [HttpGet]
        public async Task<IActionResult> View (int id)
        {
           var produit = await mvcDemoDbContext.produit.FirstOrDefaultAsync(x => x.idProduit == id);
            if (produit !=null) 
            {
                var viewModel = new UpdateProduitViewModel()
                {
                    idProduit = produit.idProduit,
                    nomProduit = produit.nomProduit,
                    prix = produit.prix,
                    reference = produit.reference,
                    description = produit.description,

                };
                return await Task.Run(()=>View("View",viewModel));
            }

           
            return RedirectToAction("Index");

        }

        //Pour modifier
        [HttpPost]
        public async Task<IActionResult> View (UpdateProduitViewModel model)
        {
            var produit =await mvcDemoDbContext.produit.FindAsync(model.idProduit);
            if (produit != null) 
            {
                produit.nomProduit = model.nomProduit;
                produit.prix = model.prix;
                produit.reference = model.reference;
                produit.description = model.description;

               await  mvcDemoDbContext.SaveChangesAsync();
              return RedirectToAction("Index");
                
            }
            return RedirectToAction("Index");

        }



        //delete

        [HttpPost]
        public async Task <IActionResult> Delete(UpdateProduitViewModel model)
        {
            var produit = await mvcDemoDbContext.produit.FindAsync(model.idProduit);
            if (produit != null)
            {
                mvcDemoDbContext.produit.Remove(produit);
                await mvcDemoDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }
       
    }
}
