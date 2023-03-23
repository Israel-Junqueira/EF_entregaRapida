using EntregaRapida.Models.Enum;

namespace EntregaRapida.Models{
    public class Lojista{
        private int LojistaId { get; set; }
        private string nome { get; set; }
        private string endereco { get; set; }
        private string telefone { get; set; }
        private string cnpj { get; set; }
        public TipoComercio tipocomercio { get; set; }

        public Proprietario proprietario { get; set; }
        public List<Historico> historico { get; set; }

    public Lojista(List<Historico> historico)
    {
        this.historico = historico;
    }
    public Lojista(string name, string endereco,string telefone,string cnpj,TipoComercio tipo, Proprietario proprietario)
    {
        this.nome = name;
        this.endereco = endereco;
        this.telefone = telefone;
        this.cnpj = cnpj;
        this.tipocomercio = tipo;
        this.proprietario = proprietario;
    }

    }
}