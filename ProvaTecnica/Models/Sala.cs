namespace ProvaTecnica.Models
{
    public class Sala
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Responsavel { get; set; }
        public byte Ativo { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }

        public virtual ICollection<Agendamento> Agendamentos { get; set; }
    }
}
