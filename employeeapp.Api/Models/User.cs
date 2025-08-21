public class User
{
    public int UserId { get; set; }
    public byte[] Password { get; set; }

    public byte[] Key { get; set; }

    public string Role { get; set; } = string.Empty;

    public Employee? Employee { get; set; }
}