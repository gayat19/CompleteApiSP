using System.ComponentModel.DataAnnotations;

public class Department
{
    // [Key]//Indicates that the following attribute is teh primary key
    public int DepartmentNumber { get; set; }
    public string Name { get; set; } = string.Empty;

    public ICollection<Employee>? Employees { get; set; } //Navigation property- This is not mandit
}