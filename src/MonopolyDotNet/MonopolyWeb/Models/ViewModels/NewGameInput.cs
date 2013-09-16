using System.ComponentModel.DataAnnotations;
using MonopolyWeb.Models.Core;

namespace MonopolyWeb.Models.ViewModels
{
  public class NewGameInput
  {
    [Required]
    [MaxLength(40, ErrorMessage = "Name cannot be longer than 40 characters.")]
    public string Name { get; set; }
    [Required]
    public Totem? Totem { get; set; }
    [Required]
    public string Opponent1 { get; set; }
    [Required]
    public string Opponent2 { get; set; }
    [Required]
    public string Opponent3 { get; set; }
  }
}