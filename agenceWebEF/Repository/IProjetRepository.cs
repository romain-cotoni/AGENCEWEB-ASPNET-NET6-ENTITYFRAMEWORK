using agenceWebEF.Models;

namespace agenceWebEF.Repository
{
    public interface IProjetRepository
    {
        public List<Projet> findAllProjetsByEntrepriseId(int IdEtp);
        public Projet? findProjetById(int IdPrj);
        public Projet createProjet(Projet projet);
        public bool update(Projet projet);

    }
}
