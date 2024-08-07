using Domain.Attributes;
using Microsoft.AspNetCore.Identity;
using System;

namespace Domain.Users
{
    [Auditable]
    public class User : IdentityUser
    {
        public string FullName { get; set; }
    }
}