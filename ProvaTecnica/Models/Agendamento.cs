namespace ProvaTecnica.Models
{
    public class Agendamento
    {
        public int Id { get; set; }
        public int SalaId { get; set; }
        public DateOnly DataAgendamento { get; set; }
        public TimeOnly HoraInicio { get; set; }
        public TimeOnly HoraFim { get; set; }
        public bool Cafe { get; set; }
        public int CafeQuantidade { get; set; }
        public string CafeDescricao { get; set; }
        public string Responsavel { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }

        public virtual Sala Sala { get; set; }
    }
}
