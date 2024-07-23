using Microsoft.AspNetCore.Identity;

namespace rsAPI.Data.Entities
{

    public class ApplicationUser : IdentityUser
    {
        // Yeni özellikler 
        public string FullName { get; set; }
        public string ProfilePictureUrl { get; set; }
    }
}
