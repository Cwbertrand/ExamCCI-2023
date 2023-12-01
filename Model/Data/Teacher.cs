using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Model;

public class Teacher
{
    public Guid Id { get; set; }
    public StudentGroup? Groups { get; set; }
    public Guid? GroupsId { get; set; }
    [StringLength(2)]
    public string Firstname { get; set; }
    public IdentityUser? User { get; set; }
}
