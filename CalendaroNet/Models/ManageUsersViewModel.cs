using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace CalendaroNet.Models
{
    public class ManageUsersViewModel
    {
        public IdentityUser[] Administrators { get; set; }

        public IdentityUser[] Everyone { get; set;}
    }
}