using agenceWebEF.Models;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;


namespace agenceWebEF.Repository
{
    public class CoordonneesRepository : ICoordonneesRepository
    {
        private readonly agencewebContext _context;

        public CoordonneesRepository(agencewebContext context)
        {
            _context = context;
        }
        public Coordonnee findCoordonneeById(int id)
        {
            Coordonnee? crd = null;
            try
            {
                crd = this._context.Coordonnees.FirstOrDefault(c => c.IdCrd == id);            
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine("id"+ id +" pas trouvée :" + e);
            }
            return crd;
        }

        public Coordonnee createCoordonnee(Coordonnee coordonnee)
        {
            _context.Coordonnees.Add(coordonnee);
            _context.SaveChanges();
            return coordonnee;
        }

        public bool updateCoordonneeById(Coordonnee crd)
        {
            try
            {
                //_context.Coordonnees.FirstOrDefault(c => c.IdCrd == crd.IdCrd);
                _context.Update(crd);
               
                _context.SaveChanges();
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine("id" + crd.IdCrd + "  :" + e);
                return false;
            }
            return true;
        }
    }
}
