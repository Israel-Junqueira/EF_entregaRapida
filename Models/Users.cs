using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EntregaRapida.Models.Enum;
using Microsoft.AspNetCore.Identity;

namespace EntregaRapida.Models{
    public class Users : IdentityUser{
        [Display(Name ="Nome do usuario")] 
        public string UserName { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Compare("Email")]
        [DataType(DataType.EmailAddress)]
         [Display(Name ="Confirmar Email")] 
        public string EmailConfirmed { get; set; }
        [DataType(DataType.Password)]
        public string PasswordHash { get; set; }
        [Compare("Password")]
        [DataType(DataType.Password)]
         [Display(Name ="Confirmar Password")] 
        public string PasswordConfirmed { get; set; }

    }
}