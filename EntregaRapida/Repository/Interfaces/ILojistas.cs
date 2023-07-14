using EntregaRapida.Models;

namespace EntregaRapida.Repository.Interfaces{
    
    public interface ILojistas{
        public List<Lojista> Lista_de_Lojistas {get;}
        public Lojista Endereco_lojista(string lojista);
        public  string GetTipoComercio(string idUser);
    }
}