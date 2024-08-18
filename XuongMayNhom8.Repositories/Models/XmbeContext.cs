using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace XuongMayNhom8.Repositories.Models;

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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Chuyen>(entity =>
        {
            entity.HasKey(e => e.Machuyen).HasName("PK__CHUYEN__7A5DB08147BFEA78");

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
            entity.HasKey(e => e.Macv).HasName("PK__CONGVIEC__603F183470057A7A");

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
                .HasConstraintName("FK_DH_FR_CV");
        });

        modelBuilder.Entity<Danhmuc>(entity =>
        {
            entity.HasKey(e => e.Madm).HasName("PK__DANHMUC__603F005C3FC2CA8A");

            entity.ToTable("DANHMUC");

            entity.Property(e => e.Madm)
                .ValueGeneratedNever()
                .HasColumnName("MADM");
            entity.Property(e => e.Tendm)
                .HasMaxLength(50)
                .HasColumnName("TENDM");
        });

        modelBuilder.Entity<Donhang>(entity =>
        {
            entity.HasKey(e => e.Madon).HasName("PK__DONHANG__77CDC41B3DFACFD3");

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
            entity.HasKey(e => e.Masp).HasName("PK__SANPHAM__60228A322772A29D");

            entity.ToTable("SANPHAM");

            entity.Property(e => e.Masp)
                .ValueGeneratedNever()
                .HasColumnName("MASP");
            entity.Property(e => e.GiaBan).HasColumnType("money");
            entity.Property(e => e.Madm).HasColumnName("MADM");
            entity.Property(e => e.Mota)
                .HasColumnType("text")
                .HasColumnName("MOTA");
            entity.Property(e => e.Tensp).HasColumnName("TENSP");
            entity.Property(e => e.XuatXu)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.MadmNavigation).WithMany(p => p.Sanphams)
                .HasForeignKey(d => d.Madm)
                .HasConstraintName("FK_DM_FR_SP");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
