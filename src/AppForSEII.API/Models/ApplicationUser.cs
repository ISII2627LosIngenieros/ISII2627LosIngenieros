using Microsoft.AspNetCore.Identity;

namespace AppForSEII.API.Models;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    public ApplicationUser()
    {
    }
    public ApplicationUser(string id, string name, string surname, string userName)
    {
        Id = id;
        Name = name;
        Surname = surname;
        UserName = userName;
        Email = userName;
    }
    public ApplicationUser(string id, string name, string surname, string userName, int age, string dni, string sex)
    {
        Id = id;
        Name = name;
        Surname = surname;
        UserName = userName;
        Email = userName;
        Age = age;
        DNI = dni;
        Sex = sex;
    }

    [Required]
    public Int32 Age { get; set; }

    [Required] 
    [StringLength(9)]
    public String DNI { get; set; }

    [Required] 
    [StringLength(100)]
    public String Name { get; set; }

    [Required] 
    [StringLength(9)]
    public String Sex { get; set; }

    [Required]
    [StringLength(50)]
    public String Surname { get; set; }

    //Email, PhoneNumber y UserName ya vienen de IdentityUser, no hhay que añadirlos aquí
}
