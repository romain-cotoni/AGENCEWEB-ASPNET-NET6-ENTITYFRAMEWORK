using agenceWebEF.Models;

namespace agenceWebEF.Repository
{
    public interface IEntrepriseRepository
    {
        public List<Entreprise> findAllEntreprises();
        public List<Entreprise> findEntrepriseByName(String nom, string siret);
        public Entreprise? findEntrepriseById(int id);
        public List<Entreprise> findEntreprises(List<String> criteres);
        public Entreprise createEntreprise(Entreprise entreprise);
        public bool updateEntrepriseById(Entreprise entreprise);
    }
}
