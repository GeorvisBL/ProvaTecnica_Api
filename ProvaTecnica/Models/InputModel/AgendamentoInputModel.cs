namespace ProvaTecnica.Models.InputModel
{
    public class AgendamentoInputModel
    {
        public int SalaId { get; set; }
        public string DataAgendamento { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFim { get; set; }
        public bool Cafe { get; set; }
        public int CafeQuantidade { get; set; }
        public string CafeDescricao { get; set; }
        public string Responsavel { get; set; }
    }
}
