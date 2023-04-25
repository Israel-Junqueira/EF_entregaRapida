using EntregaRapida.Models.Enum;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace EntregaRapida.ViewModel
{
    public class EntregadorUsersViewModel :IdentityUser
    {

          //identity
        [Display(Name = "Nome do usuario")]
        [Required]
        public string NomeUsuario { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Confirmar Email")]
        [Compare("Email")]
        public string EmailConfirmar { get; set; }

        [Display(Name = "Senha")]
        [Required]
        public string Senha { get; set; }
        [Compare("Senha")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Password")]
        [Required]
        public string Senhaconfirmar { get; set; }
        
        private string _nome;
        private string _endereco;
        private string _DDD;
        private string _celular;
        private string _CNH;
  
   
        public int PlataformaId { get; set; }
        [EnumDataType(typeof(Veiculo))] //1:1 OK
        private Veiculo _veiculo { get; set; }
        [EnumDataType(typeof(Modalidade))] //1:1 ok
        private Modalidade _modalidade { get; set; }


        [Required]
        [Display(Name = "Nome do Entregador")]
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        [Required]
        [Display(Name = "Endereço")]
        public string Endereco
        {
            get { return _endereco; }
            set { _endereco = value; }
        }
        [Required]
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
        [Required]
        [MaxLength(11), MinLength(11)]
        public string CNH
        {
            get { return _CNH; }
            set { _CNH = value; }
        }

        public Modalidade Modalidade
        {
            get { return _modalidade; }
            set { _modalidade = value; }
        }
        public Veiculo Veiculo
        {
            get { return _veiculo; }
            set { _veiculo = value; }
        }
    }
}
