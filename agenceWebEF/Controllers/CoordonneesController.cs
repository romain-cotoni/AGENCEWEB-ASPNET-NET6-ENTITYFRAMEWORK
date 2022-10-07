using agenceWebEF.Models;
using agenceWebEF.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace agenceWebEF.Controllers
{
    public class CoordonneesController : Controller
    {
        private ICoordonneesRepository CoordonneesRepository;

        public CoordonneesController(ICoordonneesRepository coordonneesRepository)
        {
            this.CoordonneesRepository = coordonneesRepository;
        }

        public ActionResult GetCreate(int IdEtp)
        {
            ViewBag.IdEtp = IdEtp;
            return View("Create");
        }

        public ActionResult PostCreate([Bind("IdCrd,TelCrd,EmailCrd,AdresseCrd,Adresse2Crd,VilleCrd,PostalCrd,PaysCrd,IdEtp")] Coordonnee coordonnee)
        {
            Coordonnee newCoordonnee = CoordonneesRepository.createCoordonnee(coordonnee);
            return RedirectToAction("Client", "Entreprises", new { id = newCoordonnee.IdEtp });
        }

        public ActionResult GetEdit(int IdCrd)
        {
            Coordonnee crd = this.CoordonneesRepository.findCoordonneeById(IdCrd);
            return View("Edit", crd);            
        }

        public ActionResult PostEdit([Bind("IdCrd,TelCrd,EmailCrd,AdresseCrd,Adresse2Crd,VilleCrd,PostalCrd,PaysCrd,IdEtp")] Coordonnee coordonnee)
        {
            bool update = CoordonneesRepository.updateCoordonneeById(coordonnee);
            return RedirectToAction("Client", "Entreprises", new { id = coordonnee.IdEtp });
        }      
    }
}
