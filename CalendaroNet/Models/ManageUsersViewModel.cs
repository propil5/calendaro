using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace CalendaroNet.Models
{
    public class ManageUsersViewModel
    {
        public ApplicationUser[] Administrators { get; set; }

        public ApplicationUser[] Everyone { get; set;}
    }
}