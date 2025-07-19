using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Asp.Net_LoginImplementation.Models;

public partial class UserLoginContext : DbContext
{
    public UserLoginContext()
    {
    }

    public UserLoginContext(DbContextOptions<UserLoginContext> options)
        : base(options)
    {
    }

    public virtual DbSet<UserLogin> UserLogins { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=RIZWAN\\MSSQLSERVER2019;Initial Catalog=UserLogin;User ID=sa;Password=abc@123;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserLogin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserLogi__3214EC07DD882CBC");

            entity.ToTable("UserLogin");

            entity.Property(e => e.PasswordHash).HasMaxLength(250);
            entity.Property(e => e.UserName).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
