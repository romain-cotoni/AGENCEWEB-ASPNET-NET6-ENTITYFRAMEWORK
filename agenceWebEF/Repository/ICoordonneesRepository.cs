using agenceWebEF.Models;

namespace agenceWebEF.Repository
{
    public interface ICoordonneesRepository
    {
        public Coordonnee findCoordonneeById(int id);
        public Coordonnee createCoordonnee(Coordonnee coordonnee);
        public bool updateCoordonneeById(Coordonnee crd);
    }
}
