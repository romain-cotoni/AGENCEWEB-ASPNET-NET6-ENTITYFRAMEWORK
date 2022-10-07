using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using agenceWebEF.Models;
using System.Net;
using agenceWebEF.Repository;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace agenceWebEF.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EntreprisesController : Controller
    {
        private IEntrepriseRepository EntrepriseRepository;

        public EntreprisesController(IEntrepriseRepository entrepriseRepository)
        {
            EntrepriseRepository = entrepriseRepository;
        }

        public async Task<IActionResult> ListeClients()
        {            
            List<Entreprise> entreprises = EntrepriseRepository.findAllEntreprises();
            return View(entreprises);
        }

        public async Task<IActionResult> Client(int id)
        {
            Entreprise entreprise = null;
            entreprise = EntrepriseRepository.findEntrepriseById(id);
            return View(entreprise);
        }

        public async Task<IActionResult> GetCreate()
        {                   
            return View("Create");
        }
        public ActionResult PostCreate([Bind("IdEtp,NomEtp,SiretEtp,ActiviteEtp")] Entreprise entreprise)
        {
            Entreprise newEntreprise = EntrepriseRepository.createEntreprise(entreprise);
            return RedirectToAction("Client", "Entreprises", new { id = newEntreprise.IdEtp });
        }

        public ActionResult GetEdit(int IdEtp)
        {
            Entreprise entp = this.EntrepriseRepository.findEntrepriseById(IdEtp);
            return View("Edit", entp);
        }

        public ActionResult PostEdit([Bind("IdEtp,NomEtp,SiretEtp,ActiviteEtp")] Entreprise entreprise)
        {
            bool update = EntrepriseRepository.updateEntrepriseById(entreprise);
            return RedirectToAction("Client", "Entreprises", new { id = entreprise.IdEtp });
        }

        public ActionResult Details()
        {
            return View();
        }
    }
}
