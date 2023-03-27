using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntregaRapida.Models{

    public class Proprietario{
        [Key]
        private int Idproprietario { get; set; }
        [Required]
        public string nome { get; set; }
        [Required]
        public string cpf { get; set; }
        [Required]
        public string  telefone { get; set; }
        [Required]
        public string email { get; set; }

        [ForeignKey("Idlojista")] // ✓ 1:1 falta por no dbContext  
        public Proprietario proprietario { get; set; }

    }
}