using System;
using System.Collections.Generic;
using ChampionsLeague.Domain.EntitiesDB;
using Microsoft.EntityFrameworkCore;

namespace ChampionsLeague.Domain.DataDB;

public partial class ChampionLeagueDbContext : DbContext
{
    public ChampionLeagueDbContext()
    {
    }

    public ChampionLeagueDbContext(DbContextOptions<ChampionLeagueDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<Club> Clubs { get; set; }

    public virtual DbSet<Match> Matches { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderLine> OrderLines { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Season> Seasons { get; set; }

    public virtual DbSet<Seat> Seats { get; set; }

    public virtual DbSet<Stadium> Stadia { get; set; }

    public virtual DbSet<StadiumSection> StadiumSections { get; set; }

    public virtual DbSet<Subscription> Subscriptions { get; set; }

    public virtual DbSet<SubscriptionAssignment> SubscriptionAssignments { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<TicketAssignment> TicketAssignments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQL22_VIVES;Database=ChampionsLeague;Trusted_Connection=True;TrustServerCertificate=True; MultipleActiveResultSets=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.ProviderKey).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.Name).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Club>(entity =>
        {
            entity.HasKey(e => e.ClubId).HasName("PK__Club__D35058C74F19380C");

            entity.ToTable("Club");

            entity.Property(e => e.ClubId).HasColumnName("ClubID");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.HomeStadiumId).HasColumnName("HomeStadiumID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.HomeStadium).WithMany(p => p.Clubs)
                .HasForeignKey(d => d.HomeStadiumId)
                .HasConstraintName("FK_Team_HomeStadium");
        });

        modelBuilder.Entity<Match>(entity =>
        {
            entity.HasKey(e => e.MatchId).HasName("PK__Match__4218C8373ECD3C9A");

            entity.ToTable("Match", tb => tb.HasTrigger("TRG_StadiumMinimumCapacity"));

            entity.Property(e => e.MatchId).HasColumnName("MatchID");
            entity.Property(e => e.StadiumId).HasColumnName("StadiumID");

            entity.HasOne(d => d.AwayClubNavigation).WithMany(p => p.MatchAwayClubNavigations)
                .HasForeignKey(d => d.AwayClub)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Match_AwayClub");

            entity.HasOne(d => d.HomeClubNavigation).WithMany(p => p.MatchHomeClubNavigations)
                .HasForeignKey(d => d.HomeClub)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Match_HomeClub");

            entity.HasOne(d => d.Stadium).WithMany(p => p.Matches)
                .HasForeignKey(d => d.StadiumId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Match_Stadium");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__C3905BAF67098B15");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Cart");
            entity.Property(e => e.UserId).HasMaxLength(450);

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Orders_AspNetUsers");
        });

        modelBuilder.Entity<OrderLine>(entity =>
        {
            entity.HasKey(e => e.LineId);

            entity.ToTable("OrderLine", tb => tb.HasTrigger("trg_OrderLine_QuantityRules"));

            entity.Property(e => e.LineId).HasColumnName("LineID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Quantity)
                .HasDefaultValue(1)
                .HasColumnName("quantity");
            entity.Property(e => e.StadiumSectionId).HasColumnName("StadiumSectionID");
            entity.Property(e => e.StaticUnitPrice).HasColumnType("decimal(8, 2)");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderLines)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK_OrderLine_Order");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderLines)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderLine_Product");

            entity.HasOne(d => d.StadiumSection).WithMany(p => p.OrderLines)
                .HasForeignKey(d => d.StadiumSectionId)
                .HasConstraintName("FK_OrderLine_StadiumSection");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Product__B40CC6ED9F3C398F");

            entity.ToTable("Product");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.DynamicUnitPrice).HasColumnType("decimal(8, 2)");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Type)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Season>(entity =>
        {
            entity.HasKey(e => e.SeasonId).HasName("PK__Season__C1814E189EF4D4FB");

            entity.ToTable("Season");

            entity.Property(e => e.SeasonId).HasColumnName("SeasonID");
        });

        modelBuilder.Entity<Seat>(entity =>
        {
            entity.HasKey(e => e.SeatId).HasName("PK__Seat__311713D3A6402C8C");

            entity.ToTable("Seat", tb => tb.HasTrigger("TRG_SectionCapacityLimit"));

            entity.HasIndex(e => new { e.SectionId, e.SeatNumber }, "UQ_Seat_Section_SeatNumber").IsUnique();

            entity.Property(e => e.SeatId).HasColumnName("SeatID");
            entity.Property(e => e.SectionId).HasColumnName("SectionID");
        });

        modelBuilder.Entity<Stadium>(entity =>
        {
            entity.HasKey(e => e.StadiumId).HasName("PK__Stadium__ED8330389EE99BCE");

            entity.ToTable("Stadium");

            entity.Property(e => e.StadiumId).HasColumnName("StadiumID");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<StadiumSection>(entity =>
        {
            entity.HasKey(e => e.SectionId).HasName("PK_StadiumSection_1");

            entity.ToTable("StadiumSection");

            entity.HasIndex(e => e.SectionId, "IX_StadiumSection");

            entity.Property(e => e.SectionId).HasColumnName("SectionID");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.StadiumId).HasColumnName("StadiumID");

            entity.HasOne(d => d.Stadium).WithMany(p => p.StadiumSections)
                .HasForeignKey(d => d.StadiumId)
                .HasConstraintName("FK_Section_Stadium");
        });

        modelBuilder.Entity<Subscription>(entity =>
        {
            entity.HasKey(e => e.SubscriptionId).HasName("PK__Subscription");

            entity.ToTable("Subscription");

            entity.Property(e => e.SubscriptionId).HasColumnName("SubscriptionID");
            entity.Property(e => e.ClubId).HasColumnName("ClubID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.SeasonId).HasColumnName("SeasonID");

            entity.HasOne(d => d.Club).WithMany(p => p.Subscriptions)
                .HasForeignKey(d => d.ClubId)
                .HasConstraintName("FK_Sub_Club");

            entity.HasOne(d => d.Product).WithMany(p => p.Subscriptions)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_Sub_Product");

            entity.HasOne(d => d.Season).WithMany(p => p.Subscriptions)
                .HasForeignKey(d => d.SeasonId)
                .HasConstraintName("FK_Subscription_Season");
        });

        modelBuilder.Entity<SubscriptionAssignment>(entity =>
        {
            entity.HasKey(e => e.AssignmentId).HasName("PK_SubscriptionAssignment_1");

            entity.ToTable("SubscriptionAssignment");

            entity.HasIndex(e => new { e.UserId, e.Active, e.SubscriptionId }, "UQ_SubscriptionPerUserPerClub").IsUnique();

            entity.Property(e => e.AssignmentId).HasColumnName("AssignmentID");
            entity.Property(e => e.Active).HasDefaultValue(true);
            entity.Property(e => e.SeatId).HasColumnName("SeatID");
            entity.Property(e => e.SubscriptionId).HasColumnName("SubscriptionID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Seat).WithMany(p => p.SubscriptionAssignments)
                .HasForeignKey(d => d.SeatId)
                .HasConstraintName("FK_SubscriptionAssignment_Seat");

            entity.HasOne(d => d.Subscription).WithMany(p => p.SubscriptionAssignments)
                .HasForeignKey(d => d.SubscriptionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SubscriptionAssignment_Subscription");

            entity.HasOne(d => d.User).WithMany(p => p.SubscriptionAssignments)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SubscriptionAssignment_User");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.ToTable("Ticket");

            entity.Property(e => e.TicketId).HasColumnName("TicketID");
            entity.Property(e => e.MatchId).HasColumnName("MatchID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Match).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.MatchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ticket_Match");

            entity.HasOne(d => d.Product).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ticket_Product");
        });

        modelBuilder.Entity<TicketAssignment>(entity =>
        {
            entity.HasKey(e => e.AssignmentId).HasName("PK_TicketAssignment_1");

            entity.ToTable("TicketAssignment", tb => tb.HasTrigger("trg_TicketAssignment_Rules"));

            entity.Property(e => e.AssignmentId).HasColumnName("AssignmentID");
            entity.Property(e => e.Active).HasDefaultValue(true);
            entity.Property(e => e.SeatId).HasColumnName("SeatID");
            entity.Property(e => e.TicketId).HasColumnName("TicketID");
            entity.Property(e => e.UserId)
                .HasMaxLength(450)
                .HasColumnName("UserID");

            entity.HasOne(d => d.Seat).WithMany(p => p.TicketAssignments)
                .HasForeignKey(d => d.SeatId)
                .HasConstraintName("FK_TicketAssignment_Seat");

            entity.HasOne(d => d.Ticket).WithMany(p => p.TicketAssignments)
                .HasForeignKey(d => d.TicketId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TicketAssignment_Ticket");

            entity.HasOne(d => d.User).WithMany(p => p.TicketAssignments)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TicketAssignment_User");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
