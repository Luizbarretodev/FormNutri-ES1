using FormNutri_ES1.Context;
using FormNutri_ES1.DTOs;
using FormNutri_ES1.Entities;
using FormNutri_ES1.Enums;
using FormNutri_ES1.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FormNutri_ES1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AvaliacoesController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly EbiaCalculationService _ebiaService;

    public AvaliacoesController(AppDbContext context, EbiaCalculationService ebiaService)
    {
        _context = context;
        _ebiaService = ebiaService;
    }

    [HttpPost]
    public async Task<ActionResult<AvaliacaoResponse>> Criar(CriarAvaliacaoRequest request)
    {
        if (!request.ConsentimentoLgpd)
            return BadRequest("Consentimento é obrigatório para registrar a avaliação.");

        var respostaEbia = new RespostaEbia
        {
            Pergunta1 = ParseResposta(request.RespostaEbia.Pergunta1),
            Pergunta2 = ParseResposta(request.RespostaEbia.Pergunta2),
            Pergunta3 = ParseResposta(request.RespostaEbia.Pergunta3),
            Pergunta4 = ParseResposta(request.RespostaEbia.Pergunta4),
            Pergunta5 = ParseResposta(request.RespostaEbia.Pergunta5),
            Pergunta6 = ParseResposta(request.RespostaEbia.Pergunta6),
            Pergunta7 = ParseResposta(request.RespostaEbia.Pergunta7),
            Pergunta8 = ParseResposta(request.RespostaEbia.Pergunta8),
        };

        var pontuacao = _ebiaService.CalcularPontuacao(respostaEbia);
        var classificacao = _ebiaService.Classificar(pontuacao);

        var registro = new RegistroAvaliacao
        {
            AplicadorId = request.AplicadorId,
            DataColeta = DateTime.UtcNow,
            ConsentimentoLGPD = true,
            Respondente = new Respondente
            {
                Nome = request.Respondente.Nome,
                Idade = request.Respondente.Idade,
                Genero = request.Respondente.Genero,
                RacaCor = request.Respondente.RacaCor,
                Escolaridade = request.Respondente.Escolaridade,
                EstadoCivil = request.Respondente.EstadoCivil,
                SituacaoEmprego = request.Respondente.SituacaoEmprego,
                RecebeBolsaFamilia = request.Respondente.RecebeBolsaFamilia,
                Dependentes = request.Respondente.Dependentes,
                Religiao = request.Respondente.Religiao,
            },
            MarcadorConsumo = new MarcadorConsumo
            {
                RefeicoesRealizadas = request.MarcadorConsumo.RefeicoesRealizadas,
                UsoTelaRefeicoes = ParseResposta(request.MarcadorConsumo.UsoTelaRefeicoes),
                ConsumoFeijao = ParseResposta(request.MarcadorConsumo.ConsumoFeijao),
                ConsumoFrutas = ParseResposta(request.MarcadorConsumo.ConsumoFrutas),
                ConsumoVerduras = ParseResposta(request.MarcadorConsumo.ConsumoVerduras),
                ConsumoEmbutidos = ParseResposta(request.MarcadorConsumo.ConsumoEmbutidos),
                ConsumoBebidasAdocadas = ParseResposta(request.MarcadorConsumo.ConsumoBebidasAdocadas),
                ConsumoMiojo = ParseResposta(request.MarcadorConsumo.ConsumoMiojo),
                ConsumoDoces = ParseResposta(request.MarcadorConsumo.ConsumoDoces),
            },
            RespostaEbia = respostaEbia,
            PontuacaoEbia = pontuacao,
            Classificacao = classificacao,
        };

        _context.RegistroAvaliacoes.Add(registro);
        await _context.SaveChangesAsync();

        return Ok(new AvaliacaoResponse(registro.Id, pontuacao, classificacao.ToString(), registro.DataColeta));
    }

    [HttpGet("distribuicao")]
    public async Task<ActionResult> Distribuicao()
    {
        var dados = await _context.RegistroAvaliacoes
            .GroupBy(a => a.Classificacao)
            .Select(g => new { Classificacao = g.Key.ToString(), Total = g.Count() })
            .ToListAsync();

        return Ok(dados);
    }

    private static Resposta ParseResposta(string valor) => valor switch
    {
        "sim" => Resposta.Sim,
        "nao" => Resposta.Nao,
        "naosei" => Resposta.NaoSabe,
        _ => Resposta.NaoRespondido
    };
}