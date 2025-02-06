using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.models;

public record UserModel
{
    [Required]
    [StringLength(100)]
    [DisplayName("Your name")]
    public string FirstName { get; set; }
    
    
    [Required]
    [StringLength(100)]
    [DisplayName("Last name")]
    public string LastName { get; set; }
    
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    [Phone]
    [DisplayName("Phone number")]
    public string PhoneNumber { get; set; }
}
