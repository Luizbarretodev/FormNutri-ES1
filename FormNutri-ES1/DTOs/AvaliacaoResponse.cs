namespace FormNutri_ES1.DTOs;

public class AvaliacaoResponse
{
    public int Id { get; set; }

    public int PontuacaoEbia { get; set; }

    public string Classificacao { get; set; } = string.Empty;

    public DateTime DataColeta { get; set; }
}