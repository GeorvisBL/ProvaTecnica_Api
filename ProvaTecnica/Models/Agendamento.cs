namespace ProvaTecnica.Models
{
    public class Agendamento
    {
        public int Id { get; set; }
        public int SalaId { get; set; }
        public string DataAgendamento { get; set; }
        public string HoraInicioAgendamento { get; set; }
        public string HoraFimAgendamento { get; set; }
        public byte Cafe { get; set; }
        public int CafeQuantidade { get; set; }
        public string CafeDescrição { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }

        public virtual Sala Sala { get; set; }
    }
}
