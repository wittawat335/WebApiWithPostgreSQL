using System;
using System.Collections.Generic;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DBContext;

public partial class sampleDBContext : DbContext
{
    public sampleDBContext()
    {
    }

    public sampleDBContext(DbContextOptions<sampleDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<actor> actor { get; set; }

    public virtual DbSet<actor_info> actor_info { get; set; }

    public virtual DbSet<address> address { get; set; }

    public virtual DbSet<category> category { get; set; }

    public virtual DbSet<city> city { get; set; }

    public virtual DbSet<country> country { get; set; }

    public virtual DbSet<customer> customer { get; set; }

    public virtual DbSet<customer_list> customer_list { get; set; }

    public virtual DbSet<film> film { get; set; }

    public virtual DbSet<film_actor> film_actor { get; set; }

    public virtual DbSet<film_category> film_category { get; set; }

    public virtual DbSet<film_list> film_list { get; set; }

    public virtual DbSet<inventory> inventory { get; set; }

    public virtual DbSet<language> language { get; set; }

    public virtual DbSet<nicer_but_slower_film_list> nicer_but_slower_film_list { get; set; }

    public virtual DbSet<payment> payment { get; set; }

    public virtual DbSet<rental> rental { get; set; }

    public virtual DbSet<sales_by_film_category> sales_by_film_category { get; set; }

    public virtual DbSet<sales_by_store> sales_by_store { get; set; }

    public virtual DbSet<staff> staff { get; set; }

    public virtual DbSet<staff_list> staff_list { get; set; }

    public virtual DbSet<store> store { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresEnum("mpaa_rating", new[] { "G", "PG", "PG-13", "R", "NC-17" });

        modelBuilder.Entity<actor>(entity =>
        {
            entity.HasKey(e => e.actor_id).HasName("actor_pkey");

            entity.HasIndex(e => e.last_name, "idx_actor_last_name");

            entity.Property(e => e.first_name).HasMaxLength(45);
            entity.Property(e => e.last_name).HasMaxLength(45);
            entity.Property(e => e.last_update)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<actor_info>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("actor_info");

            entity.Property(e => e.first_name).HasMaxLength(45);
            entity.Property(e => e.last_name).HasMaxLength(45);
        });

        modelBuilder.Entity<address>(entity =>
        {
            entity.HasKey(e => e.address_id).HasName("address_pkey");

            entity.HasIndex(e => e.city_id, "idx_fk_city_id");

            entity.Property(e => e.address1)
                .HasMaxLength(50)
                .HasColumnName("address");
            entity.Property(e => e.address2).HasMaxLength(50);
            entity.Property(e => e.district).HasMaxLength(20);
            entity.Property(e => e.last_update)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.phone).HasMaxLength(20);
            entity.Property(e => e.postal_code).HasMaxLength(10);
        });

        modelBuilder.Entity<category>(entity =>
        {
            entity.HasKey(e => e.category_id).HasName("category_pkey");

            entity.Property(e => e.last_update)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.name).HasMaxLength(25);
        });

        modelBuilder.Entity<city>(entity =>
        {
            entity.HasKey(e => e.city_id).HasName("city_pkey");

            entity.HasIndex(e => e.country_id, "idx_fk_country_id");

            entity.Property(e => e.city1)
                .HasMaxLength(50)
                .HasColumnName("city");
            entity.Property(e => e.last_update)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<country>(entity =>
        {
            entity.HasKey(e => e.country_id).HasName("country_pkey");

            entity.Property(e => e.country1)
                .HasMaxLength(50)
                .HasColumnName("country");
            entity.Property(e => e.last_update)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<customer>(entity =>
        {
            entity.HasKey(e => e.customer_id).HasName("customer_pkey");

            entity.HasIndex(e => e.address_id, "idx_fk_address_id");

            entity.HasIndex(e => e.store_id, "idx_fk_store_id");

            entity.HasIndex(e => e.last_name, "idx_last_name");

            entity.Property(e => e.activebool)
                .IsRequired()
                .HasDefaultValueSql("true");
            entity.Property(e => e.create_date).HasDefaultValueSql("('now'::text)::date");
            entity.Property(e => e.email).HasMaxLength(50);
            entity.Property(e => e.first_name).HasMaxLength(45);
            entity.Property(e => e.last_name).HasMaxLength(45);
            entity.Property(e => e.last_update)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<customer_list>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("customer_list");

            entity.Property(e => e.address).HasMaxLength(50);
            entity.Property(e => e.city).HasMaxLength(50);
            entity.Property(e => e.country).HasMaxLength(50);
            entity.Property(e => e.phone).HasMaxLength(20);
            entity.Property(e => e.zip_code)
                .HasMaxLength(10)
                .HasColumnName("zip code");
        });

        modelBuilder.Entity<film>(entity =>
        {
            entity.HasKey(e => e.film_id).HasName("film_pkey");

            entity.HasIndex(e => e.fulltext, "film_fulltext_idx").HasMethod("gist");

            entity.HasIndex(e => e.language_id, "idx_fk_language_id");

            entity.HasIndex(e => e.title, "idx_title");

            entity.Property(e => e.last_update)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.rental_duration).HasDefaultValueSql("3");
            entity.Property(e => e.rental_rate)
                .HasPrecision(4, 2)
                .HasDefaultValueSql("4.99");
            entity.Property(e => e.replacement_cost)
                .HasPrecision(5, 2)
                .HasDefaultValueSql("19.99");
            entity.Property(e => e.title).HasMaxLength(255);
        });

        modelBuilder.Entity<film_actor>(entity =>
        {
            entity.HasKey(e => new { e.actor_id, e.film_id }).HasName("film_actor_pkey");

            entity.HasIndex(e => e.film_id, "idx_fk_film_id");

            entity.Property(e => e.last_update)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<film_category>(entity =>
        {
            entity.HasKey(e => new { e.film_id, e.category_id }).HasName("film_category_pkey");

            entity.Property(e => e.last_update)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<film_list>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("film_list");

            entity.Property(e => e.category).HasMaxLength(25);
            entity.Property(e => e.price).HasPrecision(4, 2);
            entity.Property(e => e.title).HasMaxLength(255);
        });

        modelBuilder.Entity<inventory>(entity =>
        {
            entity.HasKey(e => e.inventory_id).HasName("inventory_pkey");

            entity.HasIndex(e => new { e.store_id, e.film_id }, "idx_store_id_film_id");

            entity.Property(e => e.last_update)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<language>(entity =>
        {
            entity.HasKey(e => e.language_id).HasName("language_pkey");

            entity.Property(e => e.last_update)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.name)
                .HasMaxLength(20)
                .IsFixedLength();
        });

        modelBuilder.Entity<nicer_but_slower_film_list>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("nicer_but_slower_film_list");

            entity.Property(e => e.category).HasMaxLength(25);
            entity.Property(e => e.price).HasPrecision(4, 2);
            entity.Property(e => e.title).HasMaxLength(255);
        });

        modelBuilder.Entity<payment>(entity =>
        {
            entity.HasKey(e => e.payment_id).HasName("payment_pkey");

            entity.HasIndex(e => e.customer_id, "idx_fk_customer_id");

            entity.HasIndex(e => e.rental_id, "idx_fk_rental_id");

            entity.HasIndex(e => e.staff_id, "idx_fk_staff_id");

            entity.Property(e => e.amount).HasPrecision(5, 2);
            entity.Property(e => e.payment_date).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.rental).WithMany(p => p.payment)
                .HasForeignKey(d => d.rental_id)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("payment_rental_id_fkey");
        });

        modelBuilder.Entity<rental>(entity =>
        {
            entity.HasKey(e => e.rental_id).HasName("rental_pkey");

            entity.HasIndex(e => e.inventory_id, "idx_fk_inventory_id");

            entity.HasIndex(e => new { e.rental_date, e.inventory_id, e.customer_id }, "idx_unq_rental_rental_date_inventory_id_customer_id").IsUnique();

            entity.Property(e => e.last_update)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.rental_date).HasColumnType("timestamp without time zone");
            entity.Property(e => e.return_date).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.inventory).WithMany(p => p.rental)
                .HasForeignKey(d => d.inventory_id)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("rental_inventory_id_fkey");
        });

        modelBuilder.Entity<sales_by_film_category>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("sales_by_film_category");

            entity.Property(e => e.category).HasMaxLength(25);
        });

        modelBuilder.Entity<sales_by_store>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("sales_by_store");
        });

        modelBuilder.Entity<staff>(entity =>
        {
            entity.HasKey(e => e.staff_id).HasName("staff_pkey");

            entity.Property(e => e.active)
                .IsRequired()
                .HasDefaultValueSql("true");
            entity.Property(e => e.email).HasMaxLength(50);
            entity.Property(e => e.first_name).HasMaxLength(45);
            entity.Property(e => e.last_name).HasMaxLength(45);
            entity.Property(e => e.last_update)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.password).HasMaxLength(40);
            entity.Property(e => e.username).HasMaxLength(16);
        });

        modelBuilder.Entity<staff_list>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("staff_list");

            entity.Property(e => e.address).HasMaxLength(50);
            entity.Property(e => e.city).HasMaxLength(50);
            entity.Property(e => e.country).HasMaxLength(50);
            entity.Property(e => e.phone).HasMaxLength(20);
            entity.Property(e => e.zip_code)
                .HasMaxLength(10)
                .HasColumnName("zip code");
        });

        modelBuilder.Entity<store>(entity =>
        {
            entity.HasKey(e => e.store_id).HasName("store_pkey");

            entity.HasIndex(e => e.manager_staff_id, "idx_unq_manager_staff_id").IsUnique();

            entity.Property(e => e.last_update)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone");
        });
        modelBuilder.HasSequence("actor_actor_id_seq");
        modelBuilder.HasSequence("address_address_id_seq");
        modelBuilder.HasSequence("category_category_id_seq");
        modelBuilder.HasSequence("city_city_id_seq");
        modelBuilder.HasSequence("country_country_id_seq");
        modelBuilder.HasSequence("customer_customer_id_seq");
        modelBuilder.HasSequence("film_film_id_seq");
        modelBuilder.HasSequence("inventory_inventory_id_seq");
        modelBuilder.HasSequence("language_language_id_seq");
        modelBuilder.HasSequence("payment_payment_id_seq");
        modelBuilder.HasSequence("rental_rental_id_seq");
        modelBuilder.HasSequence("staff_staff_id_seq");
        modelBuilder.HasSequence("store_store_id_seq");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
