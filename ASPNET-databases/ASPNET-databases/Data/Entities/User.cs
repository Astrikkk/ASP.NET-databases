using Microsoft.AspNetCore.Identity;

namespace ASPNET_databases.Data.Entities
{
    public class User : IdentityUser
    {
        public DateTime? Birthdate { get; set; }
    }
}
