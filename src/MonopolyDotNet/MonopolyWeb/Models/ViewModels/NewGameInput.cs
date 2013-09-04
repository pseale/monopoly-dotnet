using System.ComponentModel.DataAnnotations;

namespace MonopolyWeb.Models.ViewModels
{
  public class NewGameInput
  {
    [Required]
    [MaxLength(50, ErrorMessage = "Name cannot be longer than 40 characters.")]
    public string Name { get; set; }
    [Required]
    public string Totem { get; set; }
    [Required]
    public string Second { get; set; }
    [Required]
    public string Third { get; set; }
    [Required]
    public string Fourth { get; set; }
  }
}