using System.ComponentModel.DataAnnotations;

public class ContactFormModel
{
  [Required]
  public string Name { get; set; }
  [Required]
  public string LastName { get; set; }
  [Required]
  public string Email { get; set; }
  [Required]
  public string Message { get; set; }
}
