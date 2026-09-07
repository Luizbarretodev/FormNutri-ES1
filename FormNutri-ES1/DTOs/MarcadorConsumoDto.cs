using FormNutri_ES1.Enums;

namespace FormNutri_ES1.DTOs;

public class MarcadorConsumoDto
{
    public List<string> RefeicoesRealizadas { get; set; } = new();
    public string UsoTelaRefeicoes { get; set; } = string.Empty;
    public string ConsumoFeijao { get; set; } = string.Empty;
    public string ConsumoFrutas { get; set; } = string.Empty;
    public string ConsumoVerduras { get; set; } = string.Empty;
    public string ConsumoEmbutidos { get; set; } = string.Empty;
    public string ConsumoBebidasAdocadas { get; set; } = string.Empty;
    public string ConsumoMiojo { get; set; } = string.Empty;
    public string ConsumoDoces { get; set; } = string.Empty;
}