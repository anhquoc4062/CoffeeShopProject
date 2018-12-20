﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CoffeeShopProject.Models
{
    public partial class CoffeeShopContext : DbContext
    {
        public CoffeeShopContext()
        {
        }

        public CoffeeShopContext(DbContextOptions<CoffeeShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BanAn> BanAn { get; set; }
        public virtual DbSet<ChiTietGioHang> ChiTietGioHang { get; set; }
        public virtual DbSet<ChiTietHoaDon> ChiTietHoaDon { get; set; }
        public virtual DbSet<ChucVu> ChucVu { get; set; }
        public virtual DbSet<DanhGia> DanhGia { get; set; }
        public virtual DbSet<GioHang> GioHang { get; set; }
        public virtual DbSet<HoaDon> HoaDon { get; set; }
        public virtual DbSet<KhachHang> KhachHang { get; set; }
        public virtual DbSet<LoaiThucDon> LoaiThucDon { get; set; }
        public virtual DbSet<NhanVien> NhanVien { get; set; }
        public virtual DbSet<PhanCong> PhanCong { get; set; }
        public virtual DbSet<PhanQuyen> PhanQuyen { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoan { get; set; }
        public virtual DbSet<TinhThanh> TinhThanh { get; set; }
        public virtual DbSet<ThucDon> ThucDon { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-O9FKFQB\\SQLEXPRESS; Database=CoffeeShop;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BanAn>(entity =>
            {
                entity.HasKey(e => e.MaBan);

                entity.Property(e => e.MaBan).HasColumnName("maBan");

                entity.Property(e => e.SoGhe).HasColumnName("soGhe");
            });

            modelBuilder.Entity<ChiTietGioHang>(entity =>
            {
                entity.HasKey(e => e.MaCtgioHang)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.MaCtgioHang).HasColumnName("maCTGioHang");

                entity.Property(e => e.MaGioHang).HasColumnName("maGioHang");

                entity.Property(e => e.MaThucDon).HasColumnName("maThucDon");

                entity.Property(e => e.SoLuong).HasColumnName("soLuong");

                entity.HasOne(d => d.MaGioHangNavigation)
                    .WithMany(p => p.ChiTietGioHang)
                    .HasForeignKey(d => d.MaGioHang)
                    .HasConstraintName("FK_CHITIETGIOHANG_REFERENCE_GIOHANG");

                entity.HasOne(d => d.MaThucDonNavigation)
                    .WithMany(p => p.ChiTietGioHang)
                    .HasForeignKey(d => d.MaThucDon)
                    .HasConstraintName("FK_CHITIETGIOHANG_REFERENCE_THUCDON");
            });

            modelBuilder.Entity<ChiTietHoaDon>(entity =>
            {
                entity.HasKey(e => e.MaChiTiet);

                entity.Property(e => e.MaChiTiet).HasColumnName("maChiTiet");

                entity.Property(e => e.DonGia).HasColumnName("donGia");

                entity.Property(e => e.MaHoaDon).HasColumnName("maHoaDon");

                entity.Property(e => e.MaThucDon).HasColumnName("maThucDon");

                entity.Property(e => e.SoLuong).HasColumnName("soLuong");

                entity.HasOne(d => d.MaHoaDonNavigation)
                    .WithMany(p => p.ChiTietHoaDon)
                    .HasForeignKey(d => d.MaHoaDon)
                    .HasConstraintName("FK_CHITIETH_REFERENCE_HOADON");

                entity.HasOne(d => d.MaThucDonNavigation)
                    .WithMany(p => p.ChiTietHoaDon)
                    .HasForeignKey(d => d.MaThucDon)
                    .HasConstraintName("FK_CHITIETH_REFERENCE_THUCDON");
            });

            modelBuilder.Entity<ChucVu>(entity =>
            {
                entity.HasKey(e => e.MaChucVu)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.MaChucVu).HasColumnName("maChucVu");

                entity.Property(e => e.TenChucVu)
                    .HasColumnName("tenChucVu")
                    .HasMaxLength(254);
            });

            modelBuilder.Entity<DanhGia>(entity =>
            {
                entity.HasKey(e => e.MaDanhGia);

                entity.Property(e => e.MaDanhGia).HasColumnName("maDanhGia");

                entity.Property(e => e.LoiNhanXet)
                    .HasColumnName("loiNhanXet")
                    .HasColumnType("ntext");

                entity.Property(e => e.MaTaiKhoan).HasColumnName("maTaiKhoan");

                entity.Property(e => e.MaThucDon).HasColumnName("maThucDon");

                entity.Property(e => e.NgayDanhGia)
                    .HasColumnName("ngayDanhGia")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<GioHang>(entity =>
            {
                entity.HasKey(e => e.MaGioHang)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.MaGioHang).HasColumnName("maGioHang");

                entity.Property(e => e.MaKhachHang).HasColumnName("maKhachHang");

                entity.Property(e => e.MaTaiKhoan).HasColumnName("maTaiKhoan");

                entity.Property(e => e.NgayDat)
                    .HasColumnName("ngayDat")
                    .HasColumnType("datetime");

                entity.Property(e => e.TongCong).HasColumnName("tongCong");

                entity.Property(e => e.TrangThai).HasColumnName("trangThai");

                entity.HasOne(d => d.MaKhachHangNavigation)
                    .WithMany(p => p.GioHang)
                    .HasForeignKey(d => d.MaKhachHang)
                    .HasConstraintName("FK_GIOHANG_REFERENCE_KHACHHANG");
            });

            modelBuilder.Entity<HoaDon>(entity =>
            {
                entity.HasKey(e => e.MaHoaDon)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.MaHoaDon).HasColumnName("maHoaDon");

                entity.Property(e => e.MaBan).HasColumnName("maBan");

                entity.Property(e => e.MaNhanVien).HasColumnName("maNhanVien");

                entity.Property(e => e.SoKhach).HasColumnName("soKhach");

                entity.Property(e => e.ThoiGianLap)
                    .HasColumnName("thoiGianLap")
                    .HasColumnType("datetime");

                entity.Property(e => e.TongTien).HasColumnName("tongTien");

                entity.HasOne(d => d.MaBanNavigation)
                    .WithMany(p => p.HoaDon)
                    .HasForeignKey(d => d.MaBan)
                    .HasConstraintName("FK_HOADON_REFERENCE_BANAN");

                entity.HasOne(d => d.MaNhanVienNavigation)
                    .WithMany(p => p.HoaDon)
                    .HasForeignKey(d => d.MaNhanVien)
                    .HasConstraintName("FK_HOADON_REFERENCE_NHANVIEN");
            });

            modelBuilder.Entity<KhachHang>(entity =>
            {
                entity.HasKey(e => e.MaKhachHang)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.MaKhachHang).HasColumnName("maKhachHang");

                entity.Property(e => e.DiaChi)
                    .HasColumnName("diaChi")
                    .HasMaxLength(254);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(254);

                entity.Property(e => e.MaTaiKhoan).HasColumnName("maTaiKhoan");

                entity.Property(e => e.MaTinhThanh).HasColumnName("maTinhThanh");

                entity.Property(e => e.SoDt)
                    .HasColumnName("soDT")
                    .HasMaxLength(20);

                entity.Property(e => e.TenKhachHang)
                    .HasColumnName("tenKhachHang")
                    .HasMaxLength(254);

                entity.HasOne(d => d.MaTaiKhoanNavigation)
                    .WithMany(p => p.KhachHang)
                    .HasForeignKey(d => d.MaTaiKhoan)
                    .HasConstraintName("FK_KHACHHANG_REFERENCE_TAIKHOAN");
            });

            modelBuilder.Entity<LoaiThucDon>(entity =>
            {
                entity.HasKey(e => e.MaLoai)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.MaLoai).HasColumnName("maLoai");

                entity.Property(e => e.MaLoaiCha).HasColumnName("maLoaiCha");

                entity.Property(e => e.TenLoai)
                    .HasColumnName("tenLoai")
                    .HasMaxLength(254);
            });

            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.HasKey(e => e.MaNhanVien)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.MaNhanVien).HasColumnName("maNhanVien");

                entity.Property(e => e.Cmnd)
                    .HasColumnName("CMND")
                    .HasMaxLength(20);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(254);

                entity.Property(e => e.HinhAnh)
                    .HasColumnName("hinhAnh")
                    .HasMaxLength(254);

                entity.Property(e => e.HoTen)
                    .HasColumnName("hoTen")
                    .HasMaxLength(254);

                entity.Property(e => e.Luong).HasColumnName("luong");

                entity.Property(e => e.MaChucVu).HasColumnName("maChucVu");

                entity.Property(e => e.MaTaiKhoan).HasColumnName("maTaiKhoan");

                entity.Property(e => e.MoTa)
                    .HasColumnName("moTa")
                    .HasColumnType("ntext");

                entity.Property(e => e.NgayBatDau)
                    .HasColumnName("ngayBatDau")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.MaChucVuNavigation)
                    .WithMany(p => p.NhanVien)
                    .HasForeignKey(d => d.MaChucVu)
                    .HasConstraintName("FK_NHANVIEN_REFERENCE_CHUCVU");

                entity.HasOne(d => d.MaTaiKhoanNavigation)
                    .WithMany(p => p.NhanVien)
                    .HasForeignKey(d => d.MaTaiKhoan)
                    .HasConstraintName("FK_NHANVIEN_REFERENCE_TAIKHOAN");
            });

            modelBuilder.Entity<PhanCong>(entity =>
            {
                entity.HasKey(e => e.MaPhanCong)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.MaPhanCong).HasColumnName("maPhanCong");

                entity.Property(e => e.Ca).HasColumnName("ca");

                entity.Property(e => e.MaBan).HasColumnName("maBan");

                entity.Property(e => e.MaNhanVien).HasColumnName("maNhanVien");

                entity.Property(e => e.NgayPhanCong)
                    .HasColumnName("ngayPhanCong")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.MaBanNavigation)
                    .WithMany(p => p.PhanCong)
                    .HasForeignKey(d => d.MaBan)
                    .HasConstraintName("FK_PHANCONG_REFERENCE_BANAN");
            });

            modelBuilder.Entity<PhanQuyen>(entity =>
            {
                entity.HasKey(e => e.MaPhanQuyen)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.MaPhanQuyen)
                    .HasColumnName("maPhanQuyen")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.QuyenHan)
                    .HasColumnName("quyenHan")
                    .HasMaxLength(254);
            });

            modelBuilder.Entity<TaiKhoan>(entity =>
            {
                entity.HasKey(e => e.MaTaiKhoan)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.MaTaiKhoan).HasColumnName("maTaiKhoan");

                entity.Property(e => e.AnhDaiDien)
                    .HasColumnName("anhDaiDien")
                    .HasMaxLength(254);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MaPhanQuyen)
                    .HasColumnName("maPhanQuyen")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MatKhau)
                    .IsRequired()
                    .HasColumnName("matKhau")
                    .HasMaxLength(254);

                entity.Property(e => e.TenTaiKhoan)
                    .IsRequired()
                    .HasColumnName("tenTaiKhoan")
                    .HasMaxLength(254);

                entity.HasOne(d => d.MaPhanQuyenNavigation)
                    .WithMany(p => p.TaiKhoan)
                    .HasForeignKey(d => d.MaPhanQuyen)
                    .HasConstraintName("FK_TAIKHOAN_REFERENCE_PHANQUYEN");
            });

            modelBuilder.Entity<TinhThanh>(entity =>
            {
                entity.HasKey(e => e.MaTinhThanh);

                entity.Property(e => e.MaTinhThanh).HasColumnName("maTinhThanh");

                entity.Property(e => e.TenTinhThanh)
                    .HasColumnName("tenTinhThanh")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<ThucDon>(entity =>
            {
                entity.HasKey(e => e.MaThucDon)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.MaThucDon).HasColumnName("maThucDon");

                entity.Property(e => e.Gia).HasColumnName("gia");

                entity.Property(e => e.HinhAnh)
                    .HasColumnName("hinhAnh")
                    .HasMaxLength(254);

                entity.Property(e => e.KhuyenMai).HasColumnName("khuyenMai");

                entity.Property(e => e.MaLoai).HasColumnName("maLoai");

                entity.Property(e => e.MoTa)
                    .HasColumnName("moTa")
                    .HasColumnType("ntext");

                entity.Property(e => e.TenThucDon)
                    .HasColumnName("tenThucDon")
                    .HasMaxLength(254);

                entity.HasOne(d => d.MaLoaiNavigation)
                    .WithMany(p => p.ThucDon)
                    .HasForeignKey(d => d.MaLoai)
                    .HasConstraintName("FK_THUCDON_REFERENCE_LOAITHUC");
            });
        }
    }
}
