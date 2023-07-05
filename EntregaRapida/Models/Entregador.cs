
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EntregaRapida.Models.Enum;
using Microsoft.AspNetCore.Identity;

namespace EntregaRapida.Models
{
    public class Entregador
    {
        public int EntregadorId ;
        private string _nome ;
        private string _endereco;
        private string _DDD ;
        private string _celular ;
        private bool _statusEntregador;
        private string _CNH ;
        private int _pontuacao;
        private int _numeroEntrega;
        private int _corridasIncompletas;
        //chaves estrangeitas
        [EnumDataType(typeof(Veiculo))] //1:1 OK
        private Veiculo _veiculo { get; set; }
        [EnumDataType(typeof(Modalidade))] //1:1 ok
        private Modalidade _modalidade { get; set; }
        public string Idaspnetuser { get; set; }
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
            this._nome = Nome;
            this._endereco = endereco;
            this._DDD = DDD;
            this._celular = Celular;
            this._CNH = cnh;
            this._modalidade = modalidade;
            this._veiculo = veiculo;
        }
        [MinLength(1,ErrorMessage ="Digite um nome para o entregador")]
        [Required]
        [NotMapped]  
        [Display(Name ="Nome do Entregador")]
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        public int CorridasIncompletas
        {
            get { return _corridasIncompletas; }
            set { _corridasIncompletas= value; }
        }
   
        public bool StatusEntregador
        {
            get { return _statusEntregador; }
            set { _statusEntregador = value; }
        }

        [Required]
        [NotMapped]
        [Display(Name ="Endereço")] 
        public string Endereco
        {
            get { return _endereco; }
            set { _endereco = value; }
        }
        [Required]
        [NotMapped]
        [MaxLength(3, ErrorMessage = "Em que pais você mora? o ddd nao pode ter mais de 3 digitos"), MinLength(1, ErrorMessage = "Em que pais você mora?Insira no minimo um ddd")]
        public string DDD
        {
            get { return _DDD; }
            set { _DDD = value; }
        }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Celular
        {
            get { return _celular; }
            set { _celular = value; }
        }
        [NotMapped]
        [Required]
        [MaxLength(11), MinLength(11)]
        public string CNH
        {
            get { return _CNH; }
            set { _CNH = value; }
        }

        [Display(Name ="Pontuação")]
        [NotMapped]
          public int Pontuacao
        {
            get { return _pontuacao; }
            set { _pontuacao = value; }
        }
        [NotMapped]
        [Display(Name ="Numero de Entregas")]
            public int Numero_De_Entregas
        {
            get { return _numeroEntrega; }
            set { _numeroEntrega = value; }
        }
        [NotMapped]
        public Modalidade Modalidade
        {
            get { return _modalidade; }
            set { _modalidade = value; }
        }
        [NotMapped]
        public Veiculo Veiculo
        {
            get { return _veiculo; }
            set { _veiculo = value; }
        }


    }



}