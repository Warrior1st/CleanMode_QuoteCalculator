using CleanMode_QuoteCalculator.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace CleanMode_QuoteCalculator.Models
{
    public class AdminAssignment
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<IdentityUser> userManager;
        public AdminAssignment(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public void SeedAdminUser()
        {
            IdentityRole role = new IdentityRole { Name = "Administrator" };

            var result = roleManager.CreateAsync(role);

        }
        
    }
}
