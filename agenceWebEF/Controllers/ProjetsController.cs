using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using agenceWebEF.Models;
using agenceWebEF.Repository;

namespace agenceWebEF.Controllers
{
    public class ProjetsController : Controller
    {
        private IProjetRepository ProjetRepository;

        public ProjetsController(IProjetRepository projetRepository)
        {
            ProjetRepository = projetRepository;
        }

        public IActionResult findAllProjetsByEntreprise(int IdEtp)
        {
            List<Projet> projets = ProjetRepository.findAllProjetsByEntrepriseId(IdEtp);
            ViewBag.IdEtp = IdEtp;
            if (projets == null || projets.Count == 0)
            {
                Projet projet = new Projet();
                projet.IdEtp = IdEtp;
                projets?.Add(projet);
            }           
            return View("Listprojet",projets);
        }

        public IActionResult Details(int IdPrj)
        {
            Projet? projet = ProjetRepository.findProjetById(IdPrj);
            return View(projet);
        }

        public ActionResult GetCreate(int IdEtp)
        {
            ViewBag.IdEtp = IdEtp;
            return View("Create");
        }

        public ActionResult PostCreate([Bind("IdPrj,NomPrj,TypePrj,TypeTarifPrj,TFixePrj,NbHeurePrj,THorairePrj,DebutPrj,FinPrj,DescripPrj,InfoPrj,IdEtp")] Projet projet)
        {
            Projet newPrj = ProjetRepository.createProjet(projet);
            return RedirectToAction("Client", "Entreprises", new { id = newPrj.IdEtp });
        }

        public IActionResult Edit(int IdPrj)
        {
            Projet? projet = ProjetRepository.findProjetById(IdPrj);
            return View(projet);
        }

        public bool update(Projet projet)
        {
            ProjetRepository.update(projet);
            return true;
        }

        public IActionResult Delete(int IdPrj)
        {
            Projet? projet = ProjetRepository.findProjetById(IdPrj);
            return View(projet);
        }








        /*// GET: Projets
        public async Task<IActionResult> Index()
        {
            var agencewebContext = _context.Projets.Include(p => p.IdEtpNavigation);
            return View(await agencewebContext.ToListAsync());
        }

        // GET: Projets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Projets == null)
            {
                return NotFound();
            }

            var projet = await _context.Projets
                .Include(p => p.IdEtpNavigation)
                .FirstOrDefaultAsync(m => m.IdPrj == id);
            if (projet == null)
            {
                return NotFound();
            }

            return View(projet);
        }

        // GET: Projets/Create
        public IActionResult Create()
        {
            ViewData["IdEtp"] = new SelectList(_context.Entreprises, "IdEtp", "IdEtp");
            return View();
        }

        // POST: Projets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPrj,NomPrj,TypePrj,TypeTarifPrj,TFixePrj,NbHeurePrj,THorairePrj,DebutPrj,FinPrj,DescripPrj,InfoPrj,IdEtp")] Projet projet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEtp"] = new SelectList(_context.Entreprises, "IdEtp", "IdEtp", projet.IdEtp);
            return View(projet);
        }

        // GET: Projets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Projets == null)
            {
                return NotFound();
            }

            var projet = await _context.Projets.FindAsync(id);
            if (projet == null)
            {
                return NotFound();
            }
            ViewData["IdEtp"] = new SelectList(_context.Entreprises, "IdEtp", "IdEtp", projet.IdEtp);
            return View(projet);
        }

        // POST: Projets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPrj,NomPrj,TypePrj,TypeTarifPrj,TFixePrj,NbHeurePrj,THorairePrj,DebutPrj,FinPrj,DescripPrj,InfoPrj,IdEtp")] Projet projet)
        {
            if (id != projet.IdPrj)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjetExists(projet.IdPrj))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEtp"] = new SelectList(_context.Entreprises, "IdEtp", "IdEtp", projet.IdEtp);
            return View(projet);
        }

        // GET: Projets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Projets == null)
            {
                return NotFound();
            }

            var projet = await _context.Projets
                .Include(p => p.IdEtpNavigation)
                .FirstOrDefaultAsync(m => m.IdPrj == id);
            if (projet == null)
            {
                return NotFound();
            }

            return View(projet);
        }

        // POST: Projets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Projets == null)
            {
                return Problem("Entity set 'agencewebContext.Projets'  is null.");
            }
            var projet = await _context.Projets.FindAsync(id);
            if (projet != null)
            {
                _context.Projets.Remove(projet);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjetExists(int id)
        {
          return (_context.Projets?.Any(e => e.IdPrj == id)).GetValueOrDefault();
        }*/
    }
}
