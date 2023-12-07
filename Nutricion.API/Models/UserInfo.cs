using Microsoft.EntityFrameworkCore;

namespace Nutricion.API.Models
{
    [Keyless]
    public class UserInfo
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }
    }
}
