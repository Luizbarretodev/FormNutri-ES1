using FormNutri_ES1.Enums;

namespace FormNutri_ES1.Entities;

public class RespostaEbia
{
    public Resposta Pergunta1 { get; set; } = new();
    public Resposta Pergunta2 { get; set; } = new();
    public Resposta Pergunta3 { get; set; } = new();
    public Resposta Pergunta4 { get; set; } = new();
    public Resposta Pergunta5 { get; set; } = new();
    public Resposta Pergunta6 { get; set; } = new();
    public Resposta Pergunta7 { get; set; } = new();
    public Resposta Pergunta8 { get; set; } = new();

    public IEnumerable<Resposta> ListaRespostas()
    {
        return new[] { Pergunta1, Pergunta2, Pergunta3, Pergunta4, Pergunta5, Pergunta6, Pergunta7, Pergunta8 };
    }
}