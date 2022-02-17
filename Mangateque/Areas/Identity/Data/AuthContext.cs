<<<<<<< HEAD
﻿using Mangateque.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
=======
﻿using Microsoft.AspNetCore.Identity;
>>>>>>> tmp
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Mangateque.Data;

<<<<<<< HEAD
public class AuthContext : IdentityDbContext<MangatequeUser>
=======
public class AuthContext : IdentityDbContext<IdentityUser>
>>>>>>> tmp
{
    public AuthContext(DbContextOptions<AuthContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
