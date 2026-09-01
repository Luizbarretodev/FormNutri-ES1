using FormNutri_ES1.Enums;
using System.ComponentModel.DataAnnotations;

namespace FormNutri_ES1.Entities;

public class Usuario
{
    public int Id { get; set; }

    [Required]
    public string Nome { get; set; } = string.Empty;

    [Required]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string Senha { get; set; } = string.Empty;

    [Required]
    public PerfilUsuario Perfil { get; set; }

}