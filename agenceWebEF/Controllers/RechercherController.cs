using Microsoft.AspNetCore.Mvc;
using agenceWebEF.Models;
using Microsoft.EntityFrameworkCore;
using agenceWebEF.Repository;
using System.Data;
using System.Text;
using Microsoft.CodeAnalysis.Options;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Authorization;

//https://learn.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/updating-related-data-with-the-entity-framework-in-an-asp-net-mvc-application

namespace agenceWebEF.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RechercherController : Controller
    {
        private IEntrepriseRepository EntrepriseRepository;

        public RechercherController(IEntrepriseRepository entrepriseRepository)
        {
            EntrepriseRepository = entrepriseRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            //List<Entreprise> entp = EntrepriseRepository.findAllEntreprises();
            ViewBag.datalistnom = EntrepriseRepository.findAllEntreprises(); //"< option value ='helooworld' >";//populateDataList();
            return View();
        }

        public async Task<IActionResult> findEntrepriseByName(string nom, string siret)
        {
            ViewBag.datalistnom = EntrepriseRepository.findAllEntreprises();
            List<Entreprise> entreprises;
            if (nom != null || siret != null)
            {
                entreprises = EntrepriseRepository.findEntrepriseByName(nom, siret);
            }
            else 
            { 
                entreprises = EntrepriseRepository.findAllEntreprises();
            }

            //return RedirectToAction("Index","Rechercher",clients);
            return View("Index", entreprises);
        }

        public async Task<IActionResult> findClients()
        {
            //entreprises = await _context.Entreprises.Where(p => p.NomEtp == "simpson-industrial").ToListAsync();
            //entreprises = await _context.Entreprises.Include(p => p.Projets).ToListAsync();
            List<Entreprise> entreprises = EntrepriseRepository.findAllEntreprises();

            //return RedirectToAction("Index","Rechercher",clients);
            return View("Index", entreprises);
        }

        public StringBuilder populateDataList()
        {
            List<Entreprise> entp = EntrepriseRepository.findAllEntreprises();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < entp.Count; i++)
            {
                sb.Append(String.Format("<option value='{0}'{1}>",entp[i].NomEtp, System.Environment.NewLine));
            }
            return sb;            
        }
    }
}
