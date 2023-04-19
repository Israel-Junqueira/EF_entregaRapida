using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EntregaRapida.Models.Enum;
using Microsoft.AspNetCore.Identity;

namespace EntregaRapida.Models{
    public class Users : IdentityUser{
        [Display(Name ="Nome do usuario")] 
        public override string UserName { get; set; }
        [DataType(DataType.EmailAddress)]
        public override string Email { get; set; }
        [Compare("Email")]
        [DataType(DataType.EmailAddress)]
        [Display(Name ="Confirmar Email")] 
        public override string PasswordHash { get; set; }
        [Compare("Password")]
        [DataType(DataType.Password)]
         [Display(Name ="Confirmar Password")] 
        public string PasswordConfirmed { get; set; }

        public int EntregadorId { get; set; }
        [ForeignKey("EntregadorId")]
        public Entregador Entregador { get; set; }



    }
}