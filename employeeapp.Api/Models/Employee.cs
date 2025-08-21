using System.ComponentModel.DataAnnotations.Schema;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public string? Phone { get; set; }

    public int DepartmentId { get; set; }

    // [ForeignKey("DepartmentId")]
    public Department? Department { get; set; }//This will not be a column in the database. Its just to create and maintain teh relation
    
    public User? User { get; set; }
}