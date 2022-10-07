using agenceWebEF.Models;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;

namespace agenceWebEF.Repository
{
    public class EntrepriseRepository : IEntrepriseRepository
    {
        private readonly agencewebContext _context;

        public EntrepriseRepository(agencewebContext context)
        {
            _context = context;
        }

        public List<Entreprise> findAllEntreprises()
        {
            return this._context.Entreprises.Include(p => p.Projets).ToList();
        }

        public List<Entreprise> findEntrepriseByName(string nom, string siret)
        {            
            if(nom != null)
                if(siret != null)
                    return this._context.Entreprises.Include(p => p.Projets).Where(p => p.NomEtp == nom && p.SiretEtp == siret).ToList();
                else
                    return this._context.Entreprises.Include(p => p.Projets).Where(p => p.NomEtp == nom).ToList();
            if(siret != null)
                return this._context.Entreprises.Include(p => p.Projets).Where(p => p.SiretEtp == siret).ToList();
            return null;
        }

        public Entreprise? findEntrepriseById(int id)
        {
            return this._context.Entreprises.Include(c => c.Coordonnees).Include(p => p.Projets).FirstOrDefault(e => e.IdEtp == id);
        }

        /// <summary>
        /// retourn une liste d'entreprises recherchées par la liste des critères donnés en argument 
        /// </summary>
        /// <param name="criteres"></param>
        /// <returns>List<Entreprise></returns>
        public List<Entreprise> findEntreprises(List<String> criteres)
        {
            return null;
        }

        public Entreprise createEntreprise(Entreprise entreprise)
        {
            _context.Entreprises.Add(entreprise);
            _context.SaveChanges();
            //int id = entreprise.IdEtp;
            //Entreprise newEntreprise = this.findEntrepriseById(id);
            return entreprise;  
        }

        public bool updateEntrepriseById(Entreprise entreprise)
        {
            try
            {
                //_context.Entreprise.FirstOrDefault(c => c.IdEtp == entreprise.IdEtp);
                _context.Update(entreprise);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("id" + entreprise.IdEtp + "  :" + e);
                return false;
            }
            return true;
        }
    }
}
