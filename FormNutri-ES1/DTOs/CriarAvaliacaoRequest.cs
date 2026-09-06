namespace FormNutri_ES1.DTOs;

public class CriarAvaliacaoRequest
{
    public bool ConsentimentoLgpd { get; set; }

    public int AplicadorId { get; set; }

    public RespondenteDto Respondente { get; set; } = new();

    public MarcadorConsumoDto MarcadorConsumo { get; set; } = new();

    public RespostaEbiaDto RespostaEbia { get; set; } = new();
}
