using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EntregaRapida.Models;
using EntregaRapida.Models.Enum;
using Microsoft.AspNetCore.Identity;

namespace EntregaRapida.ViewModel
{
    public class RegistroLojistaViewModel :IdentityUser
    {
        
        public int LojistaId { get; set; }
        [Required]
        private string _nome;
        [Required]
        private string _endereco { get; set; }
        [Required]
        private string _telefone { get; set; }
        [Required]
        private string _cnpj { get; set; }
         public int PlataformaId { get; set; }
        //chaves estrangeiras
        [EnumDataType(typeof(TipoComercio))] // 1:1 ✓  ok
        private TipoComercio _tipocomercio { get; set; }
        [Display(Name = "Confirmar Email")]
        [Required]
        public string EmailConfirmed { get; set; }

        [Display(Name = "Nome do usuario")]
       [Required]
       public string NomeUsuario { get; set; }
       [MinLength(1)]
       [NotMapped]
       [Display(Name = "Nome do Comercio")]
       public string NomeComercio
       {
        get { return _nome; }
        set {_nome = value; }
       }
       [NotMapped]
       [Display(Name = "Endereço")]
        public string Endereco
        {
            get { return _endereco; }
            set { _endereco = value; }
        }
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        [Required]
        public string Senha { get; set; }
        [Compare("Senha")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Password")]
        [Required]
        public string Senhaconfirmar { get; set; }

       [NotMapped]
       [Display(Name = "Telefone")]
       [MaxLength(14), MinLength(9)]
        public string Telefone
        {
            get { return _telefone; }
            set { _telefone = value; }
        }
       [NotMapped]
       [Display(Name = "CNPJ")]
       [RegularExpression("^[0-9]{2}[0-9]{3}[0-9]{3}[0-9]{4}[0-9]{2}",ErrorMessage ="Insira o CNPJ sem (' . , - / ')")]
       [MaxLength(14), MinLength(14)]
        public string CNPJ
        {
            get { return _cnpj; }
            set { _cnpj = value; }
        }

        public TipoComercio TipoComercio
        {
            get { return _tipocomercio; }
            set { _tipocomercio = value; }
        }
    }
}
