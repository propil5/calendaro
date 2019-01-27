using Microsoft.AspNetCore.Identity;

public class ApplicationUser : IdentityUser
{
    public string Name { get; set; }
    public int Age { get; set; }

    public bool IsEmployed { get; set; }
}