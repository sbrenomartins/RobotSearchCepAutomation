using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;

namespace Domain.Entidades;

[Table("Address")]
public class Address
{
    [Key]
    public int Id { get; set; }
    public string? CEP { get; set; }
    public string? Logradouro { get; set; }
    public string? Bairro { get; set; }
    public string? UF { get; set; }
    public EnumStatus Status { get; set; } = EnumStatus.Aberto;
    public string? Robo { get; set; }
}
