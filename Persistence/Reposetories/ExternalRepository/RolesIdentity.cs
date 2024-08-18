using Microsoft.AspNetCore.Identity;
using Roles = Domain.Enums.CorrectRole;

using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Reposetories.ExternalRepository
{
    public static class RolesIdentity
    {
        public static async Task EnsureRolesAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<CorrectRole>>();
            var roles = new[] { Roles.SuberAdmin.ToString(),
             Roles.Academy.ToString(), Roles.Instructor.ToString(), Roles.Student.ToString(),
         Roles.NewUser.ToString()};

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new CorrectRole(role));
                }
            }
        }
    }
}
