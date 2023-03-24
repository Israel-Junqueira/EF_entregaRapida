using System.ComponentModel.DataAnnotations.Schema;

namespace EntregaRapida.Models{

    public class Proprietario{
        private int Idproprietario { get; set; }
        public string nome { get; set; }
        public string cpf { get; set; }

        public string  telefone { get; set; }

        public string email { get; set; }

        [ForeignKey("Idlojista")] // ✓ 1:1 falta por no dbContext  
        public Proprietario proprietario { get; set; }

    }
}