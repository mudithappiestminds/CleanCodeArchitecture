using System.ComponentModel.DataAnnotations;

public class AadharCard
{
    [Key]
    public string? Id { get; set; }

    [Required(ErrorMessage = "This field is Required")]
    [MaxLength(50, ErrorMessage = "This field must contain between 3 to 60 characters")]
    [MinLength(3, ErrorMessage = "This field must contain between 3 to 60 characters")]
    public string? Name { get; set; }
    [Required(ErrorMessage = "This field is Required")]
    public DateTime DateOfBirth { get; set; }
    [Required(ErrorMessage = "This field is Required")]
    public string? Address { get; set; }
    public string? State { get; set; }
    public string? City { get; set; }
    public List<string>? DocumentProofs { get; set; }
}