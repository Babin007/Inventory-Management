using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Data.Entities
{
    public class UserEntity
{
    public Guid Id { get; set; }

    public string Email { get; set; } = null!;
    public string Role { get; set; } = "User"; // Admin / User
}
}