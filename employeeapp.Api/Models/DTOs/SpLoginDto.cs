using System.ComponentModel.DataAnnotations;

public class SpLoginDto
{
    [Key]
    public int UserId { get; set; }
    public byte[] Password { get; set; }

    public byte[] Key { get; set; }

    public string Role { get; set; } = string.Empty;

}