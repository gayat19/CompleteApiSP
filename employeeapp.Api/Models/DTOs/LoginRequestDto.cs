using System.ComponentModel.DataAnnotations;

public class LoginRequestDto
{
    [Required(ErrorMessage ="User ID cannot be empty")]
    public int UserId { get; set; }
    [Required(ErrorMessage ="Password cannot be empty")]
    public string Password { get; set; } = string.Empty;
}