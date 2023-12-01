using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Model;

public class Teacher
{
    public Guid Id { get; set; }
    public StudentGroup? Groups { get; set; }
    public Guid? GroupsId { get; set; }

    [StringLength(2)]
    [Required(ErrorMessage = "The FirstName field is required.")]
    public string Firstname { get; set; }
    public IdentityUser? User { get; set; }
}
