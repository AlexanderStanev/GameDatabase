// ReSharper disable VirtualMemberCallInConstructor
namespace GamesDatabase.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole(string name)
            : base(name)
        {
        }
    }
}
