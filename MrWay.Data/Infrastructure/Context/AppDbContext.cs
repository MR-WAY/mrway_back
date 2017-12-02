using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MrWay.Domain.DomainModels.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace MrWay.Data.Infrastructure.Context
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}