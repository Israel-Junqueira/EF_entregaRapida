namespace EntregaRapida.Models{

    public class Proprietario{
        private int ProprietarioId { get; set; }
        public string nome { get; set; }
        public string cpf { get; set; }

        public string  telefone { get; set; }

        public string email { get; set; }
    }
}