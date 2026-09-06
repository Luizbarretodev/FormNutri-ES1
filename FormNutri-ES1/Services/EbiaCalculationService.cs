using FormNutri_ES1.Entities;
using FormNutri_ES1.Enums;

namespace FormNutri_ES1.Services;

public class EbiaCalculationService
{
    public int CalcularPontuacao(RespostaEbia respostas)
    {
        return respostas.ListaRespostas().Count(r => r == Resposta.Sim);
    }
    public Classificacao Classificar(int pontuacao)
    {
        return pontuacao switch
        {
            0 => Classificacao.SegurancaAlimentar,
            >= 1 and <= 3 => Classificacao.InsegurancaLeve,
            >= 4 and <= 5 => Classificacao.InsegurancaModerada,
            >= 6 and <= 8 => Classificacao.InsegurancaGrave,
            _ => throw new ArgumentOutOfRangeException(nameof(pontuacao), "Pontuação EBIA deve estar entre 0 e 8.")
        };
    }
}