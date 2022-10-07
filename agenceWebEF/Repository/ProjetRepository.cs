using agenceWebEF.Models;
using Microsoft.EntityFrameworkCore;

namespace agenceWebEF.Repository
{
    public class ProjetRepository: IProjetRepository
    {
        private readonly agencewebContext _context;

        public ProjetRepository(agencewebContext context)
        {
            _context = context;
        }

        public List<Projet> findAllProjetsByEntrepriseId(int IdEtp)
        {
            return this._context.Projets.Where(p => p.IdEtp == IdEtp ).ToList();
        }

        

        public Projet? findProjetById(int IdPrj)
        {
            Projet? projet = null; 
            projet = _context.Projets.FirstOrDefault();
            return projet;
        }

        public Projet createProjet(Projet projet)
        {
            _context.Projets.Add(projet);
            _context.SaveChanges();
            return projet;
        }

        public bool update(Projet projet)
        {
            try
            {
                _context.Update(projet);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("une erreur" + e);//System.Diagnostics.Debug.WriteLine("id" + entreprise.IdEtp + "  :" + e);
                return false;
            }
            return true;
        }
    }
}
