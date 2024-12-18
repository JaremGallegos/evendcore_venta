using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebAplicacionVentas.Data.Central.Entities;

public partial class CentralDbContext : DbContext
{
    public CentralDbContext()
    {
    }

    public CentralDbContext(DbContextOptions<CentralDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Analitic> Analitics { get; set; }

    public virtual DbSet<Configuration> Configurations { get; set; }

    public virtual DbSet<Content> Contents { get; set; }

    public virtual DbSet<ContentDetail> ContentDetails { get; set; }

    public virtual DbSet<ContentSection> ContentSections { get; set; }

    public virtual DbSet<ContentType> ContentTypes { get; set; }

    public virtual DbSet<Lead> Leads { get; set; }

    public virtual DbSet<LeadDetail> LeadDetails { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<PermissionContent> PermissionContents { get; set; }

    public virtual DbSet<Testimony> Testimonies { get; set; }

    public virtual DbSet<TestimonyDetail> TestimonyDetails { get; set; }

    public virtual DbSet<TestimonyType> TestimonyTypes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserAchievement> UserAchievements { get; set; }

    public virtual DbSet<UserDetail> UserDetails { get; set; }

    public virtual DbSet<UserSecure> UserSecures { get; set; }

    public virtual DbSet<UserSetting> UserSettings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=MevenConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Analitic>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__analitic__3213E83F3B59A830");

            entity.ToTable("analitic", "Central");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.PageViewed)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("page_viewed");
            entity.Property(e => e.Referrer)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("referrer");
            entity.Property(e => e.SessionDuration).HasColumnName("session_duration");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.UserIp)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("user_ip");

            entity.HasOne(d => d.User).WithMany(p => p.Analitics)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("analitic_user_user_id");
        });

        modelBuilder.Entity<Configuration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__configur__3213E83FCF865354");

            entity.ToTable("configuration", "Central");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.KeyName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("key_name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Value)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("value");

            entity.HasOne(d => d.User).WithMany(p => p.Configurations)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("configuration_user_user_id");
        });

        modelBuilder.Entity<Content>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__content__3213E83FD318556A");

            entity.ToTable("content", "Central");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("description");
            entity.Property(e => e.Title)
                .HasMaxLength(130)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("title");
        });

        modelBuilder.Entity<ContentDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__content___3213E83FE073BC9B");

            entity.ToTable("content_detail", "Central");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AclVersion)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("acl_version");
            entity.Property(e => e.ContActive)
                .HasDefaultValue(true)
                .HasColumnName("cont_active");
            entity.Property(e => e.ContDescription)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("cont_description");
            entity.Property(e => e.ContDirectory)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("cont_directory");
            entity.Property(e => e.ContEncMenu)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("cont_enc_menu");
            entity.Property(e => e.ContNickName)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("cont_nick_name");
            entity.Property(e => e.ContParent)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("cont_parent");
            entity.Property(e => e.ContRelativeLink)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("cont_relative_link");
            entity.Property(e => e.ContType)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("cont_type");
            entity.Property(e => e.ContUiActive)
                .HasDefaultValue(true)
                .HasColumnName("cont_ui_active");
            entity.Property(e => e.ContUiName)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("cont_ui_name");
            entity.Property(e => e.ContUiOrder).HasColumnName("cont_ui_order");
            entity.Property(e => e.ContentId).HasColumnName("content_id");
            entity.Property(e => e.ContentTypeId).HasColumnName("content_type_id");
            entity.Property(e => e.Date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.Directory)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("directory");
            entity.Property(e => e.PermissionsItemTable)
                .HasDefaultValue(true)
                .HasColumnName("permissions_item_table");
            entity.Property(e => e.SqlRun).HasColumnName("sql_run");
            entity.Property(e => e.SqlVersion)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("sql_version");

            entity.HasOne(d => d.Content).WithMany(p => p.ContentDetails)
                .HasForeignKey(d => d.ContentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("content_detail_content_content_id");

            entity.HasOne(d => d.ContentType).WithMany(p => p.ContentDetails)
                .HasForeignKey(d => d.ContentTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("content_detail_content_type_content_type_id");
        });

        modelBuilder.Entity<ContentSection>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__content___3213E83F21FF8EDB");

            entity.ToTable("content_section", "Central");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ContentDetailId).HasColumnName("content_detail_id");
            entity.Property(e => e.ParentSection)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("parent_section");
            entity.Property(e => e.SectionIdentifier)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("section_identifier");
            entity.Property(e => e.SectionName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("section_name");

            entity.HasOne(d => d.ContentDetail).WithMany(p => p.ContentSections)
                .HasForeignKey(d => d.ContentDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("content_section_content_detail_content_detail_id");
        });

        modelBuilder.Entity<ContentType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__content___3213E83FEE8F565A");

            entity.ToTable("content_type", "Central");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("description");
        });

        modelBuilder.Entity<Lead>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__leads__3213E83FA5E01C59");

            entity.ToTable("leads", "Central");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("name");
            entity.Property(e => e.SubscriptionDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("subscription_date");
        });

        modelBuilder.Entity<LeadDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__lead_det__3213E83FC93023E5");

            entity.ToTable("lead_detail", "Central");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.LeadsId).HasColumnName("leads_id");
            entity.Property(e => e.Message)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("message");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("phone");

            entity.HasOne(d => d.Leads).WithMany(p => p.LeadDetails)
                .HasForeignKey(d => d.LeadsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("lead_detail_leads_leads_id");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__permissi__3213E83F26199842");

            entity.ToTable("permission", "Central");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Active)
                .HasDefaultValue(true)
                .HasColumnName("active");
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("date_created");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("description");
            entity.Property(e => e.LastUpdated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("last_updated");
        });

        modelBuilder.Entity<PermissionContent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__permissi__3213E83F3FCEDCD9");

            entity.ToTable("permission_content", "Central");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Allowed)
                .HasDefaultValue(true)
                .HasColumnName("allowed");
            entity.Property(e => e.ContentDetailId).HasColumnName("content_detail_id");
            entity.Property(e => e.PermissionId).HasColumnName("permission_id");

            entity.HasOne(d => d.ContentDetail).WithMany(p => p.PermissionContents)
                .HasForeignKey(d => d.ContentDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("permission_content_content_detail_content_detail_id");

            entity.HasOne(d => d.Permission).WithMany(p => p.PermissionContents)
                .HasForeignKey(d => d.PermissionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("permission_content_permission_permission_id");
        });

        modelBuilder.Entity<Testimony>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__testimon__3213E83F53048E5B");

            entity.ToTable("testimony", "Central");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Content)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("content");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.LikeCount).HasColumnName("like_count");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.TestimonyTypeId).HasColumnName("testimony_type_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.TestimonyType).WithMany(p => p.Testimonies)
                .HasForeignKey(d => d.TestimonyTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("testimony_testimony_type_testimony_type_id");

            entity.HasOne(d => d.User).WithMany(p => p.Testimonies)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("testimony_user_user_id");
        });

        modelBuilder.Entity<TestimonyDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__testimon__3213E83F326482E7");

            entity.ToTable("testimony_detail", "Central");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("image_url");
            entity.Property(e => e.IsVisible)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("is_visible");
            entity.Property(e => e.TestimonyId).HasColumnName("testimony_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Testimony).WithMany(p => p.TestimonyDetails)
                .HasForeignKey(d => d.TestimonyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("testimony_detail_testimony_testimony_id");
        });

        modelBuilder.Entity<TestimonyType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__testimon__3213E83F82593374");

            entity.ToTable("testimony_type", "Central");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("description");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__user__3213E83FCBE5A8F2");

            entity.ToTable("user", "Central");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Active)
                .HasDefaultValue(true)
                .HasColumnName("active");
            entity.Property(e => e.Avatar)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("avatar");
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("date_created");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("email");
            entity.Property(e => e.LastUpdated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("last_updated");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("password");
            entity.Property(e => e.PermissionId).HasColumnName("permission_id");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("username");
            entity.Property(e => e.Uuid)
                .HasDefaultValueSql("(newsequentialid())")
                .HasColumnName("uuid");

            entity.HasOne(d => d.Permission).WithMany(p => p.Users)
                .HasForeignKey(d => d.PermissionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_permission_permission_id");
        });

        modelBuilder.Entity<UserAchievement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__user_ach__3213E83F3050BA0F");

            entity.ToTable("user_achievements", "Central");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AchievementTitle)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("achievement_title");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("description");
            entity.Property(e => e.EarnedAt)
                .HasDefaultValueSql("('')")
                .HasColumnType("datetime")
                .HasColumnName("earned_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Uuid)
                .HasDefaultValueSql("(newsequentialid())")
                .HasColumnName("uuid");

            entity.HasOne(d => d.User).WithMany(p => p.UserAchievements)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_achievements_user_user_id");
        });

        modelBuilder.Entity<UserDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__user_det__3213E83F190A89C0");

            entity.ToTable("user_detail", "Central");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AppleSignin)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("apple_signin");
            entity.Property(e => e.DefaultWarehouse)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("default_warehouse");
            entity.Property(e => e.Facility)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("facility");
            entity.Property(e => e.GithubSignin)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("github_signin");
            entity.Property(e => e.GoogleSigninEmail)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("google_signin_email");
            entity.Property(e => e.LastLogin)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("last_login");
            entity.Property(e => e.Pin)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("pin");
            entity.Property(e => e.Source)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("source");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.UserDetails)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_detail_user_user_id");
        });

        modelBuilder.Entity<UserSecure>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__user_sec__3213E83F470C0329");

            entity.ToTable("user_secure", "Central");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AutoBlockEmailed)
                .HasDefaultValue(true)
                .HasColumnName("auto_block_emailed");
            entity.Property(e => e.LastChallengeResponse)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("last_challenge_response");
            entity.Property(e => e.LastLoginFail)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("last_login_fail");
            entity.Property(e => e.LastUpdated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("last_updated");
            entity.Property(e => e.LastUpdatedPassword)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("last_updated_password");
            entity.Property(e => e.LoginFailCounter).HasColumnName("login_fail_counter");
            entity.Property(e => e.LoginWorkArea)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("login_work_area");
            entity.Property(e => e.PasswordHistory1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("password_history1");
            entity.Property(e => e.PasswordHistory2)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("password_history2");
            entity.Property(e => e.PasswordHistory3)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("password_history3");
            entity.Property(e => e.PasswordHistory4)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("password_history4");
            entity.Property(e => e.TotalLoginFailCounter).HasColumnName("total_login_fail_counter");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.UserSecures)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_secure_user_user_id");
        });

        modelBuilder.Entity<UserSetting>(entity =>
        {
            entity.HasKey(e => e.SettingUser).HasName("PK__user_set__56E8384FF1352416");

            entity.ToTable("user_settings", "Central");

            entity.Property(e => e.SettingUser).HasColumnName("setting_user");
            entity.Property(e => e.SettingLabel)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("setting_label");
            entity.Property(e => e.SettingValue)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("setting_value");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.UserSettings)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_settings_user_user_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
