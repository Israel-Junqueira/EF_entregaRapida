using System.ComponentModel.DataAnnotations;

namespace EntregaRapida.ViewModel{

    public class LoginViewModel{
        [Display(Name ="Usuario")]
        [Required(ErrorMessage = "Informe o nome")]
        public string UserName { get; set; }
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Informe a senha")]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}