using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using BGCatalog.Web.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace BGCatalog.Web.Data
{
    public partial class BgCatalogContext : IdentityDbContext<IdentityUser>
    {
        public BgCatalogContext()
        {
        }

        public BgCatalogContext(DbContextOptions<BgCatalogContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Boardgame> Boardgames { get; set; }
        public virtual DbSet<UserBoardgameCollection> UserBoardgameCollections { get; set; }
        public virtual DbSet<UserBoardgamePlay> UserBoardgamePlays { get; set; }
        public virtual DbSet<UserDetails> UserDetails { get; set; }

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Boardgame>(entity =>
            {
                entity.HasKey(e => e.BoardgameId)
                    .HasName("PK__Boardgam__2AB897FD8D354AB2");

                entity.Property(e => e.Bggid)
                    .IsRequired()
                    .HasColumnName("BGGID")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserBoardgameCollection>(entity =>
            {
                entity.HasKey(e => new { e.UserDetailId, e.BoardgameId })
                    .HasName("PK__UserBoar__E41B6CCFBDDA2CAB");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.HasOne(d => d.Boardgame)
                    .WithMany(p => p.UserBoardgameCollections)
                    .HasForeignKey(d => d.BoardgameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserBoardGameCollection_Boardgames");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserBoardgameCollections)
                    .HasForeignKey(d => d.UserDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserBoardGameCollection_Users");
            });

            modelBuilder.Entity<UserBoardgamePlay>(entity =>
            {
                entity.HasKey(e => e.PlayId)
                    .HasName("PK__UserBoar__7CA45EA4CD675B4C");

                entity.Property(e => e.DatePlayed).HasColumnType("datetime");

                entity.HasOne(d => d.Boardgame)
                    .WithMany(p => p.UserBoardgamePlays)
                    .HasForeignKey(d => d.BoardgameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserBoardgamePlays_Boardgames");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserBoardgamePlays)
                    .HasForeignKey(d => d.UserDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserBoardgamePlays_Users");
            });

            modelBuilder.Entity<UserDetails>(entity =>
            {
                entity.HasKey(e => e.UserDetailId)
                    .HasName("PK__Users__1788CC4C46FDF564");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });
        }
    }
}
