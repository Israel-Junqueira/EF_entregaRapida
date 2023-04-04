
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EntregaRapida.Models.Enum;

namespace EntregaRapida.Models
{
    public class Entregador
    {


        public int EntregadorId { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Endereco { get; set; }
        [Required]
        [MaxLength(3, ErrorMessage = "Em que pais você mora? o ddd nao pode ter mais de 3 digitos"), MinLength(1, ErrorMessage = "Em que pais você mora? Insira no minimo um ddd")]
        public string DDD { get; set; }
        [Required]
        [MaxLength(9), MinLength(8)]
        public string Celular { get; set; }
        [Required]
        [MaxLength(11), MinLength(11)]
        public string CNH { get; set; }
        private int _pontuacao;
        private int _numeroEntrega;
        //chaves estrangeitas
        [EnumDataType(typeof(Veiculo))] //1:1 OK
        public Veiculo veiculo { get; set; }
        [EnumDataType(typeof(Modalidade))] //1:1 ok
        public Modalidade modalidade { get; set; }
        public int PlataformaId { get; set; }
        //Relacionamento
        public Plataforma plataforma; //N:1 ok
        public virtual List<Avaliacao> avaliacao { get; set; }//1:N  falta fazer
        public virtual List<Historico> historico { get; set; } //1:N  ok
        public virtual List<Pedido> pedido { get; set; }//1:N  ok

        public Entregador()
        {

        }
        public Entregador(string Nome, string endereco, string DDD, string Celular, string cnh, Modalidade modalidade, Veiculo veiculo)
        {
            this.Nome = Nome;
            this.Endereco = endereco;
            this.DDD = DDD;
            this.Celular = Celular;
            this.CNH = cnh;
            this.modalidade = modalidade;
            this.veiculo = veiculo;
        }
    }



}