using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using XuongMayNhom8.Repositories.Models;

namespace XuongMayNhom8.Repositories.Context;

public partial class XmbeContext : DbContext
{
    public XmbeContext()
    {
    }

    public XmbeContext(DbContextOptions<XmbeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Chuyen> Chuyens { get; set; }

    public virtual DbSet<Congviec> Congviecs { get; set; }

    public virtual DbSet<Danhmuc> Danhmucs { get; set; }

    public virtual DbSet<Donhang> Donhangs { get; set; }

    public virtual DbSet<Sanpham> Sanphams { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=MSI;Database=XMBE;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Chuyen>(entity =>
        {
            entity.HasKey(e => e.Machuyen).HasName("PK__CHUYEN__7A5DB081E6DE3691");

            entity.ToTable("CHUYEN");

            entity.Property(e => e.Machuyen)
                .ValueGeneratedNever()
                .HasColumnName("MACHUYEN");
            entity.Property(e => e.Nhiemvu)
                .HasMaxLength(50)
                .HasColumnName("NHIEMVU");
            entity.Property(e => e.Socn).HasColumnName("SOCN");
            entity.Property(e => e.Vitri)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("VITRI");
        });

        modelBuilder.Entity<Congviec>(entity =>
        {
            entity.HasKey(e => e.Macv).HasName("PK__CONGVIEC__603F1834F25E4A73");

            entity.ToTable("CONGVIEC");

            entity.Property(e => e.Macv)
                .ValueGeneratedNever()
                .HasColumnName("MACV");
            entity.Property(e => e.Machuyen).HasColumnName("MACHUYEN");
            entity.Property(e => e.Madh).HasColumnName("MADH");
            entity.Property(e => e.Soluong).HasColumnName("SOLUONG");
            entity.Property(e => e.Tencv)
                .HasMaxLength(50)
                .HasColumnName("TENCV");
            entity.Property(e => e.Thoigian)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("THOIGIAN");

            entity.HasOne(d => d.MachuyenNavigation).WithMany(p => p.Congviecs)
                .HasForeignKey(d => d.Machuyen)
                .HasConstraintName("FK_CHUYEN_FR_CV");

            entity.HasOne(d => d.MadhNavigation).WithMany(p => p.Congviecs)
                .HasForeignKey(d => d.Madh)
                .HasConstraintName("FK_SP_FR_CV");
        });

        modelBuilder.Entity<Danhmuc>(entity =>
        {
            entity.HasKey(e => e.Madm).HasName("PK__DANHMUC__603F005C8EA77DBE");

            entity.ToTable("DANHMUC");

            entity.Property(e => e.Madm)
                .ValueGeneratedNever()
                .HasColumnName("MADM");
            entity.Property(e => e.Tendm)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("TENDM");
        });

        modelBuilder.Entity<Donhang>(entity =>
        {
            entity.HasKey(e => e.Madon).HasName("PK__DONHANG__77CDC41B961C67B1");

            entity.ToTable("DONHANG");

            entity.Property(e => e.Madon)
                .ValueGeneratedNever()
                .HasColumnName("MADON");
            entity.Property(e => e.Masp).HasColumnName("MASP");
            entity.Property(e => e.Ngaydat).HasColumnName("NGAYDAT");
            entity.Property(e => e.Soluong).HasColumnName("SOLUONG");

            entity.HasOne(d => d.MaspNavigation).WithMany(p => p.Donhangs)
                .HasForeignKey(d => d.Masp)
                .HasConstraintName("FK_SP_FR_DH");
        });

        modelBuilder.Entity<Sanpham>(entity =>
        {
            entity.HasKey(e => e.Masp).HasName("PK__SANPHAM__60228A32BB1CDF7F");

            entity.ToTable("SANPHAM");

            entity.Property(e => e.Masp)
                .ValueGeneratedNever()
                .HasColumnName("MASP");
            entity.Property(e => e.GiaBan).HasColumnType("money");
            entity.Property(e => e.Madm).HasColumnName("MADM");
            entity.Property(e => e.Mota)
                .HasColumnType("text")
                .HasColumnName("MOTA");
            entity.Property(e => e.Tensp)
                .IsRequired()
                .HasColumnName("TENSP");
            entity.Property(e => e.XuatXu)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.MadmNavigation).WithMany(p => p.Sanphams)
                .HasForeignKey(d => d.Madm)
                .HasConstraintName("FK_MADM_DM_FR_SP");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3213E83FBB5EC483");

            entity.ToTable("User");

            entity.HasIndex(e => e.Username, "UQ__User__F3DBC572C2AB7D95").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Role)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("role");
            entity.Property(e => e.Username)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
