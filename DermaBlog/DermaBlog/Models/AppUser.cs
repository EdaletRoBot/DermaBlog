using Microsoft.AspNetCore.Identity;

namespace DermaBlog.Models
{
    public class AppUser:IdentityUser
    {
        public String Name { get; set; }
        public String Surname { get; set; }
        public bool IsDeactive { get; set; }
    }
}
