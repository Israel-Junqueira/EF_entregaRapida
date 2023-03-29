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

      
        public int Idlojista { get; set; } // ✓ 1:1 ok
         [ForeignKey("Idlojista")] 
        public Lojista lojista { get; set; }

    }
}