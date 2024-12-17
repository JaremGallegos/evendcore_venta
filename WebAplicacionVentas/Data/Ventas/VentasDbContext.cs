using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebAplicacionVentas.Data.Ventas.Entitys;

public partial class VentasDbContext : DbContext
{
    public VentasDbContext()
    {
    }

    public VentasDbContext(DbContextOptions<VentasDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<AutomaticNotification> AutomaticNotifications { get; set; }

    public virtual DbSet<Billing> Billings { get; set; }

    public virtual DbSet<BillingDetail> BillingDetails { get; set; }

    public virtual DbSet<BillingType> BillingTypes { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerDetail> CustomerDetails { get; set; }

    public virtual DbSet<CustomerEmployee> CustomerEmployees { get; set; }

    public virtual DbSet<CustomerReward> CustomerRewards { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeDetail> EmployeeDetails { get; set; }

    public virtual DbSet<Facility> Facilities { get; set; }

    public virtual DbSet<FacilityDetail> FacilityDetails { get; set; }

    public virtual DbSet<IdentificationType> IdentificationTypes { get; set; }

    public virtual DbSet<Loyalty> Loyalties { get; set; }

    public virtual DbSet<Module> Modules { get; set; }

    public virtual DbSet<ModuleDetail> ModuleDetails { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<PaymentDetail> PaymentDetails { get; set; }

    public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    public virtual DbSet<ProductDetail> ProductDetails { get; set; }

    public virtual DbSet<Reward> Rewards { get; set; }

    public virtual DbSet<RewardDetail> RewardDetails { get; set; }

    public virtual DbSet<RewardType> RewardTypes { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<SalesDetail> SalesDetails { get; set; }

    public virtual DbSet<Section> Sections { get; set; }

    public virtual DbSet<Setting> Settings { get; set; }

    public virtual DbSet<SettingDetail> SettingDetails { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<SupplierDetail> SupplierDetails { get; set; }

    public virtual DbSet<SupplyType> SupplyTypes { get; set; }

    public virtual DbSet<System> Systems { get; set; }

    public virtual DbSet<SytemDetail> SytemDetails { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<TransactionType> TransactionTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=MevenConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__address__3213E83F684F64A0");

            entity.ToTable("address", "Ventas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("country");
            entity.Property(e => e.CountryCode)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("country_code");
            entity.Property(e => e.PostalCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("postal_code");
            entity.Property(e => e.State)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("state");
            entity.Property(e => e.Street)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("street");
            entity.Property(e => e.Zip)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("zip");
        });

        modelBuilder.Entity<AutomaticNotification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__automati__3213E83F769093CA");

            entity.ToTable("automatic_notifications", "Ventas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.Message)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("message");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("status");
            entity.Property(e => e.SystemId).HasColumnName("system_id");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("title");
            entity.Property(e => e.TriggerEvent)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("trigger_event");

            entity.HasOne(d => d.Employee).WithMany(p => p.AutomaticNotifications)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("automatic_notifications_employee_employee_id");

            entity.HasOne(d => d.System).WithMany(p => p.AutomaticNotifications)
                .HasForeignKey(d => d.SystemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("automatic_notifications_system_system_id");
        });

        modelBuilder.Entity<Billing>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__billing__3213E83F00400949");

            entity.ToTable("billing", "Ventas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Authorized)
                .HasDefaultValue(true)
                .HasColumnName("authorized");
            entity.Property(e => e.BillDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("bill_date");
            entity.Property(e => e.BillingTypeId).HasColumnName("billing_type_id");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("code");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.Date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.ProcessDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("process_date");
            entity.Property(e => e.SupplierId).HasColumnName("supplier_id");
            entity.Property(e => e.Uuid)
                .HasDefaultValueSql("(newsequentialid())")
                .HasColumnName("uuid");

            entity.HasOne(d => d.BillingType).WithMany(p => p.Billings)
                .HasForeignKey(d => d.BillingTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("billing_billing_type_billing_type_id");

            entity.HasOne(d => d.Customer).WithMany(p => p.Billings)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("billing_customer_customer_id");

            entity.HasOne(d => d.Employee).WithMany(p => p.Billings)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("billing_employee_employee_id");

            entity.HasOne(d => d.Supplier).WithMany(p => p.Billings)
                .HasForeignKey(d => d.SupplierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("billing_supplier_supplier_id");
        });

        modelBuilder.Entity<BillingDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__billing___3213E83FE7BB5E36");

            entity.ToTable("billing_detail", "Ventas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Activity)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("activity");
            entity.Property(e => e.BillProcess)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("bill_process");
            entity.Property(e => e.Billed)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("billed");
            entity.Property(e => e.BillingId).HasColumnName("billing_id");
            entity.Property(e => e.Chargetcat)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("chargetcat");
            entity.Property(e => e.CodeText)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("code_text");
            entity.Property(e => e.Encounter)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("encounter");
            entity.Property(e => e.Fee)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("decimal(6, 2)")
                .HasColumnName("fee");
            entity.Property(e => e.Groupname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("groupname");
            entity.Property(e => e.Justify)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("justify");
            entity.Property(e => e.Modifier)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("modifier");
            entity.Property(e => e.Notecodes)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("notecodes");
            entity.Property(e => e.Pricelevel)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("decimal(6, 2)")
                .HasColumnName("pricelevel");
            entity.Property(e => e.ProcessFile)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("process_file");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.RevenueCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("revenue_code");
            entity.Property(e => e.Target)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("target");
            entity.Property(e => e.Units)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("units");

            entity.HasOne(d => d.Billing).WithMany(p => p.BillingDetails)
                .HasForeignKey(d => d.BillingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("billing_detail_billing_billing_id");

            entity.HasOne(d => d.Product).WithMany(p => p.BillingDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("billing_detail_product_product_id");
        });

        modelBuilder.Entity<BillingType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__billing___3213E83FF227B443");

            entity.ToTable("billing_type", "Ventas");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.TypeName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("type_name");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__customer__3213E83FBB3A2599");

            entity.ToTable("customer", "Ventas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AddressId).HasColumnName("address_id");
            entity.Property(e => e.Dob)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("DOB");
            entity.Property(e => e.Fname)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("fname");
            entity.Property(e => e.IdentificationTypeId).HasColumnName("identification_type_id");
            entity.Property(e => e.In)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("in");
            entity.Property(e => e.LastUpdated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("last_updated");
            entity.Property(e => e.Mname)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("mname");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("phone");
            entity.Property(e => e.Sex)
                .HasDefaultValue(true)
                .HasColumnName("sex");
            entity.Property(e => e.Uuid)
                .HasDefaultValueSql("(newsequentialid())")
                .HasColumnName("uuid");

            entity.HasOne(d => d.Address).WithMany(p => p.Customers)
                .HasForeignKey(d => d.AddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("customer_address_address_id");

            entity.HasOne(d => d.IdentificationType).WithMany(p => p.Customers)
                .HasForeignKey(d => d.IdentificationTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("customer_identification_type_identification_type_id");
        });

        modelBuilder.Entity<CustomerDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__customer__3213E83FE28718AD");

            entity.ToTable("customer_detail", "Ventas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BillingNote)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("billing_note");
            entity.Property(e => e.ContactRelationship)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("contact_relationship");
            entity.Property(e => e.ContractTerms)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("xml")
                .HasColumnName("contract_terms");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("date_created");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("email");
            entity.Property(e => e.Financial)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("financial");
            entity.Property(e => e.IsRetain)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("is_retain");
            entity.Property(e => e.Language)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("language");
            entity.Property(e => e.PreferredName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("preferred_name");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("status");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("title");
            entity.Property(e => e.UpdatedBy)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("updated_by");

            entity.HasOne(d => d.Customer).WithMany(p => p.CustomerDetails)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("customer_detail_customer_customer_id");
        });

        modelBuilder.Entity<CustomerEmployee>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("customer_employee", "Ventas");

            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

            entity.HasOne(d => d.Customer).WithMany()
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("customer_employee_customer_customer_id");

            entity.HasOne(d => d.Employee).WithMany()
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("customer_employee_employee_employee_id");
        });

        modelBuilder.Entity<CustomerReward>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("customer_rewards", "Ventas");

            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.RewardId).HasColumnName("reward_id");

            entity.HasOne(d => d.Customer).WithMany()
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("customer_rewards_customer_customer_id");

            entity.HasOne(d => d.Reward).WithMany()
                .HasForeignKey(d => d.RewardId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("customer_rewards_reward_reward_id");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__employee__3213E83F27F07051");

            entity.ToTable("employee", "Ventas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("email");
            entity.Property(e => e.Fname)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("fname");
            entity.Property(e => e.HireDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("hire_date");
            entity.Property(e => e.In)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("in");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.Mname)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("mname");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("phone");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.Status)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.Uuid)
                .HasDefaultValueSql("(newsequentialid())")
                .HasColumnName("uuid");

            entity.HasOne(d => d.Role).WithMany(p => p.Employees)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("employee_role_role_id");
        });

        modelBuilder.Entity<EmployeeDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__employee__3213E83F23DDDBAF");

            entity.ToTable("employee_detail", "Ventas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AddressId).HasColumnName("address_id");
            entity.Property(e => e.ContractTerms)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("xml")
                .HasColumnName("contract_terms");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.Salary)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("salary");
            entity.Property(e => e.SeeAuth)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("see_auth");
            entity.Property(e => e.Shift)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("shift");
            entity.Property(e => e.Suffix)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("suffix");
            entity.Property(e => e.TerminationDate)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("termination_date");
            entity.Property(e => e.Valedictory)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("valedictory");

            entity.HasOne(d => d.Address).WithMany(p => p.EmployeeDetails)
                .HasForeignKey(d => d.AddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("employee_detail_address_address_id");

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeDetails)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("employee_detail_employee_employee_id");
        });

        modelBuilder.Entity<Facility>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__facility__3213E83FEE467BBB");

            entity.ToTable("facility", "Ventas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AddressId).HasColumnName("address_id");
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("date_created");
            entity.Property(e => e.Direction)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("direction");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("email");
            entity.Property(e => e.IdentificationTypeId).HasColumnName("identification_type_id");
            entity.Property(e => e.LastUpdated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("last_updated");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("phone");
            entity.Property(e => e.Uuid)
                .HasDefaultValueSql("(newsequentialid())")
                .HasColumnName("uuid");

            entity.HasOne(d => d.Address).WithMany(p => p.Facilities)
                .HasForeignKey(d => d.AddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("facility_address_address_id");

            entity.HasOne(d => d.IdentificationType).WithMany(p => p.Facilities)
                .HasForeignKey(d => d.IdentificationTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("facility_identification_type_identification_type_id");
        });

        modelBuilder.Entity<FacilityDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__facility__3213E83FE787536B");

            entity.ToTable("facility_detail", "Ventas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AcceptsAssignment)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("accepts_assignment");
            entity.Property(e => e.Attn)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("attn");
            entity.Property(e => e.BillingLocation)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("billing_location");
            entity.Property(e => e.Cci)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("cci");
            entity.Property(e => e.Color)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("color");
            entity.Property(e => e.DomainIdentifier)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("domain_identifier");
            entity.Property(e => e.ExtraValidation)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("extra_validation");
            entity.Property(e => e.FacilityCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("facility_code");
            entity.Property(e => e.FacilityId).HasColumnName("facility_id");
            entity.Property(e => e.Inactive)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("inactive");
            entity.Property(e => e.Info)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("info");
            entity.Property(e => e.PosCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("pos_code");
            entity.Property(e => e.PrimaryBusinessEntity)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("primary_business_entity");
            entity.Property(e => e.ServiceLocation)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("service_location");
            entity.Property(e => e.Website)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("website");
            entity.Property(e => e.WenoId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("weno_id");
            entity.Property(e => e.X12SenderId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("x12_sender_id");

            entity.HasOne(d => d.Facility).WithMany(p => p.FacilityDetails)
                .HasForeignKey(d => d.FacilityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("facility_detail_facility_facility_id");
        });

        modelBuilder.Entity<IdentificationType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__identifi__3213E83FDCF0EBA2");

            entity.ToTable("identification_type", "Ventas");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("description");
        });

        modelBuilder.Entity<Loyalty>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__loyalty__3213E83FFBC31027");

            entity.ToTable("loyalty", "Ventas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.MembershipLevel)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("membership_level");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("status");
            entity.Property(e => e.TotalPoints).HasColumnName("total_points");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Customer).WithMany(p => p.Loyalties)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("loyalty_customer_customer_id");
        });

        modelBuilder.Entity<Module>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__module__3213E83FD4D18D3A");

            entity.ToTable("module", "Ventas");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.ModActive)
                .HasDefaultValue(true)
                .HasColumnName("mod_active");
            entity.Property(e => e.ModDescription)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("mod_description");
            entity.Property(e => e.ModName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("mod_name");
            entity.Property(e => e.ModRelativeLink)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("mod_relative_link");
            entity.Property(e => e.ModType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("mod_type");
            entity.Property(e => e.ModUiOrder)
                .HasDefaultValueSql("('')")
                .HasColumnName("mod_ui_order");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<ModuleDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__module_d__3213E83F3D8BD3EF");

            entity.ToTable("module_detail", "Ventas");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.AclVersion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("acl_version");
            entity.Property(e => e.Directory)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("directory");
            entity.Property(e => e.ModDirectory)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("mod_directory");
            entity.Property(e => e.ModEncMenu)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("mod_enc_menu");
            entity.Property(e => e.ModNickName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("mod_nick_name");
            entity.Property(e => e.ModUiActive)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("mod_ui_active");
            entity.Property(e => e.ModUiName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("mod_ui_name");
            entity.Property(e => e.ModuleId).HasColumnName("module_id");
            entity.Property(e => e.PermissionsItemTable)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("permissions_item_table");
            entity.Property(e => e.SqlRun)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("sql_run");
            entity.Property(e => e.SqlVersion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("sql_version");

            entity.HasOne(d => d.Module).WithMany(p => p.ModuleDetails)
                .HasForeignKey(d => d.ModuleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("module_detail_module_module_id");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__payment__3213E83F2A4C17EB");

            entity.ToTable("payment", "Ventas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.BillingId).HasColumnName("billing_id");
            entity.Property(e => e.Date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.PaymentMethodId).HasColumnName("payment_method_id");
            entity.Property(e => e.SalesId).HasColumnName("sales_id");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("status");
            entity.Property(e => e.Uuid)
                .HasDefaultValueSql("(newsequentialid())")
                .HasColumnName("uuid");

            entity.HasOne(d => d.Billing).WithMany(p => p.Payments)
                .HasForeignKey(d => d.BillingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("payment_billing_billing_id");

            entity.HasOne(d => d.PaymentMethod).WithMany(p => p.Payments)
                .HasForeignKey(d => d.PaymentMethodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("payment_payment_method_payment_method_id");

            entity.HasOne(d => d.Sales).WithMany(p => p.Payments)
                .HasForeignKey(d => d.SalesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("payment_sales_sales_id");
        });

        modelBuilder.Entity<PaymentDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__payment___3213E83FC78DFC49");

            entity.ToTable("payment_detail", "Ventas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApprovalCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("approval_code");
            entity.Property(e => e.Currency)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("currency");
            entity.Property(e => e.Gateway)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("gateway");
            entity.Property(e => e.IsRefunded)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("is_refunded");
            entity.Property(e => e.Notes)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("notes");
            entity.Property(e => e.PaymentId).HasColumnName("payment_id");
            entity.Property(e => e.Reference)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("reference");
            entity.Property(e => e.RefundDate)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("refund_date");
            entity.Property(e => e.TransactionId).HasColumnName("transaction_id");

            entity.HasOne(d => d.Payment).WithMany(p => p.PaymentDetails)
                .HasForeignKey(d => d.PaymentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("payment_detail_payment_payment_id");

            entity.HasOne(d => d.Transaction).WithMany(p => p.PaymentDetails)
                .HasForeignKey(d => d.TransactionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("payment_detail_transaction_transaction_id");
        });

        modelBuilder.Entity<PaymentMethod>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__payment___3213E83FBBBEED35");

            entity.ToTable("payment_method", "Ventas");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("description");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__product__3213E83F39972230");

            entity.ToTable("product", "Ventas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Active)
                .HasDefaultValue(true)
                .HasColumnName("active");
            entity.Property(e => e.CodeNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("code_number");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.MaxStock).HasColumnName("max_stock");
            entity.Property(e => e.MinStock).HasColumnName("min_stock");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("price");
            entity.Property(e => e.ProductCategoryId).HasColumnName("product_category_id");
            entity.Property(e => e.Stock).HasColumnName("stock");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.Uuid)
                .HasDefaultValueSql("(newsequentialid())")
                .HasColumnName("uuid");

            entity.HasOne(d => d.ProductCategory).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("product_product_category_product_category_id");
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__product___3213E83F17D51384");

            entity.ToTable("product_category", "Ventas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("description");
        });

        modelBuilder.Entity<ProductDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__product___3213E83F04997E3D");

            entity.ToTable("product_detail", "Ventas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AllowCombining)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("allow_combining");
            entity.Property(e => e.Barcode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("barcode");
            entity.Property(e => e.Cost)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("cost");
            entity.Property(e => e.CypFactor)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("cyp_factor");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("description");
            entity.Property(e => e.Dimensions)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("dimensions");
            entity.Property(e => e.Dispensable)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("dispensable");
            entity.Property(e => e.ExpirationDate)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("expiration_date");
            entity.Property(e => e.Form)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("form");
            entity.Property(e => e.LastNotify)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("last_notify");
            entity.Property(e => e.NoStock)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("no_stock");
            entity.Property(e => e.OnOrder)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("on_order");
            entity.Property(e => e.Problems)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("problems");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.RelatedCode)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("related_code");
            entity.Property(e => e.SettingId).HasColumnName("setting_id");
            entity.Property(e => e.Size)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("size");
            entity.Property(e => e.SupplierId).HasColumnName("supplier_id");
            entity.Property(e => e.TaxRate)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("tax_rate");
            entity.Property(e => e.Unit)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("unit");
            entity.Property(e => e.Weight)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("weight");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("product_detail_product_product_id");

            entity.HasOne(d => d.Setting).WithMany(p => p.ProductDetails)
                .HasForeignKey(d => d.SettingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("product_detail_setting_setting_id");

            entity.HasOne(d => d.Supplier).WithMany(p => p.ProductDetails)
                .HasForeignKey(d => d.SupplierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("product_detail_supplier_supplier_id");
        });

        modelBuilder.Entity<Reward>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__reward__3213E83F040C2666");

            entity.ToTable("reward", "Ventas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Criteria)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("criteria");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("name");
            entity.Property(e => e.RewardTypeId).HasColumnName("reward_type_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.Value).HasColumnName("value");

            entity.HasOne(d => d.RewardType).WithMany(p => p.Rewards)
                .HasForeignKey(d => d.RewardTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("reward_reward_type_reward_type_id");
        });

        modelBuilder.Entity<RewardDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__reward_d__3213E83F3CA0B01B");

            entity.ToTable("reward_detail", "Ventas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ExpiryDate)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("expiry_date");
            entity.Property(e => e.Icon)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("icon");
            entity.Property(e => e.MaxUses)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("max_uses");
            entity.Property(e => e.Priority)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("priority");
            entity.Property(e => e.RedemptionCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("redemption_code");
            entity.Property(e => e.RewardId).HasColumnName("reward_id");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("status");
            entity.Property(e => e.TransactionId).HasColumnName("transaction_id");

            entity.HasOne(d => d.Reward).WithMany(p => p.RewardDetails)
                .HasForeignKey(d => d.RewardId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("reward_detail_reward_reward_id");

            entity.HasOne(d => d.Transaction).WithMany(p => p.RewardDetails)
                .HasForeignKey(d => d.TransactionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("reward_detail_transaction_transaction_id");
        });

        modelBuilder.Entity<RewardType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__reward_t__3213E83FFDDDFB81");

            entity.ToTable("reward_type", "Ventas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("description");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__role__3213E83FC465E399");

            entity.ToTable("role", "Ventas");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("description");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__sales__3213E83F84E7A377");

            entity.ToTable("sales", "Ventas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.PaymentStatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("payment_status");
            entity.Property(e => e.TotalAmount)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(6, 2)")
                .HasColumnName("total_amount");
            entity.Property(e => e.Uuid)
                .HasDefaultValueSql("(newsequentialid())")
                .HasColumnName("uuid");
        });

        modelBuilder.Entity<SalesDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__sales_de__3213E83FEDB5C405");

            entity.ToTable("sales_detail", "Ventas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CouponCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("coupon_code");
            entity.Property(e => e.DeliveryDate)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("delivery_date");
            entity.Property(e => e.DeliveryStatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("delivery_status");
            entity.Property(e => e.Discount)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("discount");
            entity.Property(e => e.Notes)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("notes");
            entity.Property(e => e.SalesChannel)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("sales_channel");
            entity.Property(e => e.SalesId).HasColumnName("sales_id");
            entity.Property(e => e.TaxAmount)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("tax_amount");

            entity.HasOne(d => d.Sales).WithMany(p => p.SalesDetails)
                .HasForeignKey(d => d.SalesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sales_detail_sales_sales_id");
        });

        modelBuilder.Entity<Section>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__section__3213E83FF2CF4BF4");

            entity.ToTable("section", "Ventas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.ModuleId).HasColumnName("module_id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("name");
            entity.Property(e => e.Order).HasColumnName("order");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Module).WithMany(p => p.Sections)
                .HasForeignKey(d => d.ModuleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("section_module_module_id");
        });

        modelBuilder.Entity<Setting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__setting__3213E83F054FF3B7");

            entity.ToTable("setting", "Ventas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Category)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("category");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.ModuleId).HasColumnName("module_id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("name");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.Value)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("value");

            entity.HasOne(d => d.Module).WithMany(p => p.Settings)
                .HasForeignKey(d => d.ModuleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("setting_module_module_id");
        });

        modelBuilder.Entity<SettingDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__setting___3213E83F1A3F322F");

            entity.ToTable("setting_detail", "Ventas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Decription)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("decription");
            entity.Property(e => e.DefaultValue)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("default_value");
            entity.Property(e => e.IsEditable)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("is_editable");
            entity.Property(e => e.LastUpdatedBy)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("last_updated_by");
            entity.Property(e => e.RequiresRestart)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("requires_restart");
            entity.Property(e => e.Scope)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("scope");
            entity.Property(e => e.SettingId).HasColumnName("setting_id");
            entity.Property(e => e.ValidationRule)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("validation_rule");

            entity.HasOne(d => d.Setting).WithMany(p => p.SettingDetails)
                .HasForeignKey(d => d.SettingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("setting_detail_setting_setting_id");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__supplier__3213E83F5A5C5080");

            entity.ToTable("supplier", "Ventas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Active)
                .HasDefaultValue(true)
                .HasColumnName("active");
            entity.Property(e => e.ContactName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("contact_name");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Direction)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("direction");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("email");
            entity.Property(e => e.In)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("in");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("phone");
            entity.Property(e => e.SupplyTypeId).HasColumnName("supply_type_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.Uuid)
                .HasDefaultValueSql("(newsequentialid())")
                .HasColumnName("uuid");

            entity.HasOne(d => d.SupplyType).WithMany(p => p.Suppliers)
                .HasForeignKey(d => d.SupplyTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("supplier_supply_type_supply_type_id");
        });

        modelBuilder.Entity<SupplierDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("supplier_detail", "Ventas");

            entity.Property(e => e.AcceptTerms)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("accept_terms");
            entity.Property(e => e.AddressId).HasColumnName("address_id");
            entity.Property(e => e.ContractTerms)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("xml")
                .HasColumnName("contract_terms");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Notes)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("notes");
            entity.Property(e => e.Rating)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("rating");
            entity.Property(e => e.SupplierId).HasColumnName("supplier_id");

            entity.HasOne(d => d.Address).WithMany()
                .HasForeignKey(d => d.AddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("supplier_detail_address_address_id");

            entity.HasOne(d => d.Supplier).WithMany()
                .HasForeignKey(d => d.SupplierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("supplier_detail_supplier_supplier_id");
        });

        modelBuilder.Entity<SupplyType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__supply_t__3213E83FA62C8B50");

            entity.ToTable("supply_type", "Ventas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("description");
        });

        modelBuilder.Entity<System>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__system__3213E83F666F5C49");

            entity.ToTable("system", "Ventas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Environment)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("environment");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("name");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("status");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAd)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_ad");
            entity.Property(e => e.Uuid)
                .HasDefaultValueSql("(newsequentialid())")
                .HasColumnName("uuid");
            entity.Property(e => e.Version)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("version");
        });

        modelBuilder.Entity<SytemDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__sytem_de__3213E83F8218E055");

            entity.ToTable("sytem_detail", "Ventas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActiveModules)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("xml")
                .HasColumnName("active_modules");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("description");
            entity.Property(e => e.LastBackupDate)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("last_backup_date");
            entity.Property(e => e.LicenseKey)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("license_key");
            entity.Property(e => e.LogLevel)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("log_level");
            entity.Property(e => e.MaxUsers)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("max_users");
            entity.Property(e => e.OsSupported)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("os_supported");
            entity.Property(e => e.SupportContact)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("support_contact");
            entity.Property(e => e.SystemId).HasColumnName("system_id");

            entity.HasOne(d => d.System).WithMany(p => p.SytemDetails)
                .HasForeignKey(d => d.SystemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sytem_detail_system_system_id");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__transact__3213E83FF0A15005");

            entity.ToTable("transaction", "Ventas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(6, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.Currency)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("currency");
            entity.Property(e => e.Date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.Status)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("status");
            entity.Property(e => e.TransactionTypeId).HasColumnName("transaction_type_id");

            entity.HasOne(d => d.TransactionType).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.TransactionTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("transaction_transaction_type_transaction_type_id");
        });

        modelBuilder.Entity<TransactionType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__transact__3213E83FFAD31259");

            entity.ToTable("transaction_type", "Ventas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("description");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
