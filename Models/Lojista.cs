using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using EntregaRapida.Models.Enum;

namespace EntregaRapida.Models{
    public class Lojista{
       
        public int LojistaId { get; set; }
        [Required]
        private string _nome;
        [Required]
        private string _endereco { get; set; }
        [Required]
        private string _telefone { get; set; }
        [Required]
        private string _cnpj { get; set; }

        //chaves estrangeiras
        [EnumDataType(typeof(TipoComercio))] // 1:1 ✓  ok
        public TipoComercio tipocomercio { get; set; }
        public int PlataformaId { get; set; }
        //Relacionamentos
        public Plataforma plataforma { get; set; }
   
        public virtual List<Historico> historico { get; set; } //1:N  ✓  ok
        public virtual List<Avaliacao> avaliacao { get; set; }//1:N  ✓  ok
        public virtual List<Pedido> pedido { get; set; }// 1:N ✓ ok

        //atributos privados
        //propriedades autoimplementadas
        //Construtores
        //Propriedades customizadas
        //outros metodos da classe
        public Lojista()
        {
            //ctor
        }

       [NotMapped]
       [Display(Name = "Nome")]
       public string Nome
       {
        get { return _nome; }
        set { _nome = value; }
       }
       [NotMapped]
       [Display(Name = "Endereço")]
        public string Endereco
        {
            get { return _endereco; }
            set { _endereco = value; }
        }

       [NotMapped]
       [Display(Name = "Telefone")]
       [MaxLength(14), MinLength(9)]
       [RegularExpression("[0-9]",ErrorMessage = "Insira apensar numero | O tamanho deve ser de 9 digitos sem DDD | 11 com ddd |"),]
        public string Telefone
        {
            get { return _telefone; }
            set { _telefone = value; }
        }
       [NotMapped]
       [Display(Name = "CNPJ")]
       [RegularExpression("[0-9]",ErrorMessage = "Use apenas numeros,O cnpj deve conter 11 numeros "),]
       [MaxLength(14), MinLength(14)]
        public string CNPJ
        {
            get { return _cnpj; }
            set { _cnpj = value; }
        }
        
        
        
       

       
    }
}