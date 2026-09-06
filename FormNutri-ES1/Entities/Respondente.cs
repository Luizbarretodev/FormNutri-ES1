namespace FormNutri_ES1.Entities;

public class Respondente
{
    public string Nome { get; set; } = string.Empty;
    public int Idade { get; set; }
    public string Genero { get; set; } = string.Empty;
    public string RacaCor { get; set; } = string.Empty;
    public string Escolaridade { get; set; } = string.Empty;
    public string EstadoCivil { get; set; } = string.Empty;
    public string SituacaoEmprego { get; set; } = string.Empty;
    public bool RecebeBolsaFamilia { get; set; }
    public string Religiao { get; set; } = string.Empty;
}