using FormNutri_ES1.Enums;

namespace FormNutri_ES1.Entities;

public class RegistroAvaliacao
{
    public int Id { get; set; }
    public DateTime DataColeta { get; set; }
    public bool ConsentimentoLGPD { get; set; }
    public int AplicadorId { get; set; }
    public Respondente Respondente { get; set; } = new();
    public MarcadorConsumo MarcadorConsumo { get; set; } = new();
    public RespostaEbia RespostaEbia { get; set; } = new();
    public int PontuacaoEbia { get; set; } = new();
    public  Classificacao Classificacao { get; set; } = new();
}