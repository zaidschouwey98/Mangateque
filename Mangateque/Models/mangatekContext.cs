using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Mangateque.Models
{
    public partial class mangatekContext : IdentityDbContext 
    {
        public mangatekContext()
        {
        }

        public mangatekContext(DbContextOptions<mangatekContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; } = null!;
        public virtual DbSet<Chapter> Chapters { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Type> Types { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;user id=root;password=root;database=mangatek", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.6.5-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.UseCollation("utf8mb4_bin")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("books");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .HasColumnName("name");

                entity.Property(e => e.Path)
                    .HasMaxLength(255)
                    .HasColumnName("path");

                entity.HasMany(d => d.Users)
                    .WithMany(p => p.Books)
                    .UsingEntity<Dictionary<string, object>>(
                        "Favorite",
                        l => l.HasOne<User>().WithMany().HasForeignKey("UsersId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_books_has_users_users1"),
                        r => r.HasOne<Book>().WithMany().HasForeignKey("BooksId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_books_has_users_books1"),
                        j =>
                        {
                            j.HasKey("BooksId", "UsersId").HasName("PRIMARY").HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                            j.ToTable("favorites").HasCharSet("utf8mb3").UseCollation("utf8mb3_general_ci");

                            j.HasIndex(new[] { "BooksId" }, "fk_books_has_users_books1_idx");

                            j.HasIndex(new[] { "UsersId" }, "fk_books_has_users_users1_idx");

                            j.IndexerProperty<int>("BooksId").HasColumnType("int(11)").HasColumnName("books_id");

                            j.IndexerProperty<int>("UsersId").HasColumnType("int(11)").HasColumnName("users_id");
                        });
            });

            modelBuilder.Entity<Chapter>(entity =>
            {
                entity.ToTable("chapters");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.HasIndex(e => e.BookId, "chapters_FK");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.BookId)
                    .HasColumnType("int(11)")
                    .HasColumnName("bookId");

                entity.Property(e => e.NumberOfPage)
                    .HasColumnType("int(11)")
                    .HasColumnName("numberOfPage");

                entity.Property(e => e.Path)
                    .HasMaxLength(100)
                    .HasColumnName("path");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.Chapters)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("chapters_FK");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("roles");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.HasIndex(e => e.Id, "roles_id_IDX");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Slug)
                    .HasMaxLength(100)
                    .HasColumnName("slug");
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.ToTable("types");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .HasColumnName("name");

                entity.HasMany(d => d.Books)
                    .WithMany(p => p.Types)
                    .UsingEntity<Dictionary<string, object>>(
                        "TypesHasBook",
                        l => l.HasOne<Book>().WithMany().HasForeignKey("BooksId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_types_has_books_books1"),
                        r => r.HasOne<Type>().WithMany().HasForeignKey("TypesId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_types_has_books_types"),
                        j =>
                        {
                            j.HasKey("TypesId", "BooksId").HasName("PRIMARY").HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                            j.ToTable("types_has_books").HasCharSet("utf8mb3").UseCollation("utf8mb3_general_ci");

                            j.HasIndex(new[] { "BooksId" }, "fk_types_has_books_books1_idx");

                            j.HasIndex(new[] { "TypesId" }, "fk_types_has_books_types_idx");

                            j.IndexerProperty<int>("TypesId").HasColumnType("int(11)").HasColumnName("types_id");

                            j.IndexerProperty<int>("BooksId").HasColumnType("int(11)").HasColumnName("books_id");
                        });
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.HasIndex(e => e.RoleId, "users_FK");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Mail)
                    .HasMaxLength(255)
                    .HasColumnName("mail");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .HasColumnName("password");

                entity.Property(e => e.RoleId)
                    .HasColumnType("int(11)")
                    .HasColumnName("roleId");

                entity.Property(e => e.Username)
                    .HasMaxLength(45)
                    .HasColumnName("username");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("users_FK");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
