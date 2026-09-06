using FormNutri_ES1.Enums;

namespace FormNutri_ES1.Entities;

public class MarcadorConsumo
{
    public List<string> RefeicoesRealizadas { get; set; }
    public Resposta UsoTelaRefeicoes { get; set; } = new();
    public Resposta ConsumoFeijao { get; set; } = new();
    public Resposta ConsumoFrutas { get; set; } = new();
    public Resposta ConsumoVerduras { get; set; } = new();
    public Resposta ConsumoEmbutidos { get; set; } = new();
    public Resposta ConsumoBebidasAdocadas { get; set; } = new();
    public Resposta ConsumoMiojo { get; set; } = new();
    public Resposta ConsumoDoces { get; set; } = new();

}