using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntregaRapida.Models{

    public class Proprietario{
      
        public int ProprietarioId { get; set; }
        [Required]
        public string nome { get; set; }
        [Required]
        private string cpf { get; set; }
        [Required]
        private string  telefone { get; set; }
        [Required]
        private string email { get; set; }

        //chaves estrangeiras
        public int LojistaId { get; set; } // ✓ 1:1 ok
        //relacionamentos
        public Lojista lojista { get; set; }

      
        public string GetNome
        {
            get { return nome; }
            set { nome = value; }
        }
        

    }
}