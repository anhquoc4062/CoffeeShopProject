﻿// <auto-generated />
using System;
using CoffeeShopProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CoffeeShopProject.Migrations
{
    [DbContext(typeof(CoffeeShopContext))]
    [Migration("20190111090328_AddProductReviews")]
    partial class AddProductReviews
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CoffeeShopProject.Models.BanAn", b =>
                {
                    b.Property<int>("MaBan")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("maBan")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("SoGhe")
                        .HasColumnName("soGhe");

                    b.HasKey("MaBan");

                    b.ToTable("BanAn");
                });

            modelBuilder.Entity("CoffeeShopProject.Models.Coupon", b =>
                {
                    b.Property<int>("MaCoupon")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("maCoupon")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("GiaKhuyenMai")
                        .HasColumnName("giaKhuyenMai");

                    b.Property<string>("MaNhap")
                        .HasColumnName("maNhap")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("MaCoupon")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.ToTable("Coupon");
                });

            modelBuilder.Entity("CoffeeShopProject.Models.ChiTietGioHang", b =>
                {
                    b.Property<int>("MaCtgioHang")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("maCTGioHang")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MaGioHang")
                        .HasColumnName("maGioHang");

                    b.Property<int?>("MaThucDon")
                        .HasColumnName("maThucDon");

                    b.Property<int?>("SoLuong")
                        .HasColumnName("soLuong");

                    b.HasKey("MaCtgioHang")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.HasIndex("MaGioHang");

                    b.HasIndex("MaThucDon");

                    b.ToTable("ChiTietGioHang");
                });

            modelBuilder.Entity("CoffeeShopProject.Models.ChiTietHoaDon", b =>
                {
                    b.Property<int>("MaChiTiet")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("maChiTiet")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double?>("DonGia")
                        .HasColumnName("donGia");

                    b.Property<int?>("MaHoaDon")
                        .HasColumnName("maHoaDon");

                    b.Property<int?>("MaThucDon")
                        .HasColumnName("maThucDon");

                    b.Property<int?>("SoLuong")
                        .HasColumnName("soLuong");

                    b.HasKey("MaChiTiet");

                    b.HasIndex("MaHoaDon");

                    b.HasIndex("MaThucDon");

                    b.ToTable("ChiTietHoaDon");
                });

            modelBuilder.Entity("CoffeeShopProject.Models.ChucVu", b =>
                {
                    b.Property<int>("MaChucVu")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("maChucVu")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TenChucVu")
                        .HasColumnName("tenChucVu")
                        .HasMaxLength(254);

                    b.HasKey("MaChucVu")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.ToTable("ChucVu");
                });

            modelBuilder.Entity("CoffeeShopProject.Models.DanhGia", b =>
                {
                    b.Property<int>("MaDanhGia")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("maDanhGia")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LoiNhanXet")
                        .HasColumnName("loiNhanXet")
                        .HasColumnType("ntext");

                    b.Property<int?>("MaTaiKhoan")
                        .HasColumnName("maTaiKhoan");

                    b.Property<int?>("MaThucDon")
                        .HasColumnName("maThucDon");

                    b.Property<DateTime?>("NgayDanhGia")
                        .HasColumnName("ngayDanhGia")
                        .HasColumnType("datetime");

                    b.HasKey("MaDanhGia");

                    b.ToTable("DanhGia");
                });

            modelBuilder.Entity("CoffeeShopProject.Models.GioHang", b =>
                {
                    b.Property<int>("MaGioHang")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("maGioHang")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MaCoupon")
                        .HasColumnName("maCoupon");

                    b.Property<int?>("MaKhachHang")
                        .HasColumnName("maKhachHang");

                    b.Property<int?>("MaTaiKhoan")
                        .HasColumnName("maTaiKhoan");

                    b.Property<DateTime?>("NgayDat")
                        .HasColumnName("ngayDat")
                        .HasColumnType("datetime");

                    b.Property<double?>("TongCong")
                        .HasColumnName("tongCong");

                    b.Property<int?>("TrangThai")
                        .HasColumnName("trangThai");

                    b.HasKey("MaGioHang")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.HasIndex("MaKhachHang");

                    b.ToTable("GioHang");
                });

            modelBuilder.Entity("CoffeeShopProject.Models.HoaDon", b =>
                {
                    b.Property<int>("MaHoaDon")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("maHoaDon")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MaBan")
                        .HasColumnName("maBan");

                    b.Property<int?>("MaNhanVien")
                        .HasColumnName("maNhanVien");

                    b.Property<int?>("SoKhach")
                        .HasColumnName("soKhach");

                    b.Property<DateTime?>("ThoiGianLap")
                        .HasColumnName("thoiGianLap")
                        .HasColumnType("datetime");

                    b.Property<double?>("TongTien")
                        .HasColumnName("tongTien");

                    b.HasKey("MaHoaDon")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.HasIndex("MaBan");

                    b.HasIndex("MaNhanVien");

                    b.ToTable("HoaDon");
                });

            modelBuilder.Entity("CoffeeShopProject.Models.KhachHang", b =>
                {
                    b.Property<int>("MaKhachHang")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("maKhachHang")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DiaChi")
                        .HasColumnName("diaChi")
                        .HasMaxLength(254);

                    b.Property<string>("Email")
                        .HasColumnName("email")
                        .HasMaxLength(254);

                    b.Property<int?>("MaTaiKhoan")
                        .HasColumnName("maTaiKhoan");

                    b.Property<int?>("MaTinhThanh")
                        .HasColumnName("maTinhThanh");

                    b.Property<string>("SoDt")
                        .HasColumnName("soDT")
                        .HasMaxLength(20);

                    b.Property<string>("TenKhachHang")
                        .HasColumnName("tenKhachHang")
                        .HasMaxLength(254);

                    b.HasKey("MaKhachHang")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.HasIndex("MaTaiKhoan");

                    b.ToTable("KhachHang");
                });

            modelBuilder.Entity("CoffeeShopProject.Models.LoaiThucDon", b =>
                {
                    b.Property<int>("MaLoai")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("maLoai")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MaLoaiCha")
                        .HasColumnName("maLoaiCha");

                    b.Property<string>("TenLoai")
                        .HasColumnName("tenLoai")
                        .HasMaxLength(254);

                    b.HasKey("MaLoai")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.ToTable("LoaiThucDon");
                });

            modelBuilder.Entity("CoffeeShopProject.Models.NgThamGia", b =>
                {
                    b.Property<int>("MaNgThamGia")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("maNgThamGia")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MaPhongChat")
                        .HasColumnName("maPhongChat");

                    b.Property<int>("MaTaiKhoan")
                        .HasColumnName("maTaiKhoan");

                    b.HasKey("MaNgThamGia");

                    b.ToTable("NgThamGia");
                });

            modelBuilder.Entity("CoffeeShopProject.Models.NhanVien", b =>
                {
                    b.Property<int>("MaNhanVien")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("maNhanVien")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cmnd")
                        .HasColumnName("CMND")
                        .HasMaxLength(20);

                    b.Property<string>("Email")
                        .HasColumnName("email")
                        .HasMaxLength(254);

                    b.Property<string>("HinhAnh")
                        .HasColumnName("hinhAnh")
                        .HasMaxLength(254);

                    b.Property<string>("HoTen")
                        .HasColumnName("hoTen")
                        .HasMaxLength(254);

                    b.Property<double?>("Luong")
                        .HasColumnName("luong");

                    b.Property<int?>("MaChucVu")
                        .HasColumnName("maChucVu");

                    b.Property<int?>("MaTaiKhoan")
                        .HasColumnName("maTaiKhoan");

                    b.Property<string>("MoTa")
                        .HasColumnName("moTa")
                        .HasColumnType("ntext");

                    b.Property<DateTime?>("NgayBatDau")
                        .HasColumnName("ngayBatDau")
                        .HasColumnType("datetime");

                    b.HasKey("MaNhanVien")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.HasIndex("MaChucVu");

                    b.HasIndex("MaTaiKhoan");

                    b.ToTable("NhanVien");
                });

            modelBuilder.Entity("CoffeeShopProject.Models.PhanCong", b =>
                {
                    b.Property<int>("MaPhanCong")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("maPhanCong")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Ca")
                        .HasColumnName("ca");

                    b.Property<int?>("MaBan")
                        .HasColumnName("maBan");

                    b.Property<int?>("MaNhanVien")
                        .HasColumnName("maNhanVien");

                    b.Property<DateTime?>("NgayPhanCong")
                        .HasColumnName("ngayPhanCong")
                        .HasColumnType("datetime");

                    b.HasKey("MaPhanCong")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.HasIndex("MaBan");

                    b.ToTable("PhanCong");
                });

            modelBuilder.Entity("CoffeeShopProject.Models.PhanQuyen", b =>
                {
                    b.Property<string>("MaPhanQuyen")
                        .HasColumnName("maPhanQuyen")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<string>("QuyenHan")
                        .HasColumnName("quyenHan")
                        .HasMaxLength(254);

                    b.HasKey("MaPhanQuyen")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.ToTable("PhanQuyen");
                });

            modelBuilder.Entity("CoffeeShopProject.Models.PhongChat", b =>
                {
                    b.Property<int>("MaPhongChat")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("maPhongChat")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TenPhongChat")
                        .HasColumnName("tenPhongChat")
                        .HasMaxLength(255);

                    b.HasKey("MaPhongChat");

                    b.ToTable("PhongChat");
                });

            modelBuilder.Entity("CoffeeShopProject.Models.TaiKhoan", b =>
                {
                    b.Property<int>("MaTaiKhoan")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("maTaiKhoan")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AnhDaiDien")
                        .HasColumnName("anhDaiDien")
                        .HasMaxLength(254);

                    b.Property<string>("Email")
                        .HasColumnName("email")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("MaPhanQuyen")
                        .HasColumnName("maPhanQuyen")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<string>("MatKhau")
                        .IsRequired()
                        .HasColumnName("matKhau")
                        .HasMaxLength(254);

                    b.Property<string>("TenTaiKhoan")
                        .IsRequired()
                        .HasColumnName("tenTaiKhoan")
                        .HasMaxLength(254);

                    b.HasKey("MaTaiKhoan")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.HasIndex("MaPhanQuyen");

                    b.ToTable("TaiKhoan");
                });

            modelBuilder.Entity("CoffeeShopProject.Models.TinNhan", b =>
                {
                    b.Property<int>("MaTinNhan")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("maTinNhan")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MaPhongChat")
                        .HasColumnName("maPhongChat");

                    b.Property<int?>("MaTaiKhoan")
                        .HasColumnName("maTaiKhoan");

                    b.Property<DateTime?>("NgayTao")
                        .HasColumnName("ngayTao")
                        .HasColumnType("datetime");

                    b.Property<string>("TinNhan1")
                        .HasColumnName("tinNhan")
                        .HasColumnType("ntext");

                    b.HasKey("MaTinNhan");

                    b.ToTable("TinNhan");
                });

            modelBuilder.Entity("CoffeeShopProject.Models.TinhThanh", b =>
                {
                    b.Property<int>("MaTinhThanh")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("maTinhThanh")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TenTinhThanh")
                        .HasColumnName("tenTinhThanh")
                        .HasMaxLength(255);

                    b.HasKey("MaTinhThanh");

                    b.ToTable("TinhThanh");
                });

            modelBuilder.Entity("CoffeeShopProject.Models.ThucDon", b =>
                {
                    b.Property<int>("MaThucDon")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("maThucDon")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double?>("Gia")
                        .HasColumnName("gia");

                    b.Property<string>("HinhAnh")
                        .HasColumnName("hinhAnh")
                        .HasMaxLength(254);

                    b.Property<int?>("KhuyenMai")
                        .HasColumnName("khuyenMai");

                    b.Property<int?>("MaLoai")
                        .HasColumnName("maLoai");

                    b.Property<string>("MoTa")
                        .HasColumnName("moTa")
                        .HasColumnType("ntext");

                    b.Property<string>("TenThucDon")
                        .HasColumnName("tenThucDon")
                        .HasMaxLength(254);

                    b.HasKey("MaThucDon")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.HasIndex("MaLoai");

                    b.ToTable("ThucDon");
                });

            modelBuilder.Entity("CoffeeShopProject.Models.ChiTietGioHang", b =>
                {
                    b.HasOne("CoffeeShopProject.Models.GioHang", "MaGioHangNavigation")
                        .WithMany("ChiTietGioHang")
                        .HasForeignKey("MaGioHang")
                        .HasConstraintName("FK_CHITIETGIOHANG_REFERENCE_GIOHANG");

                    b.HasOne("CoffeeShopProject.Models.ThucDon", "MaThucDonNavigation")
                        .WithMany("ChiTietGioHang")
                        .HasForeignKey("MaThucDon")
                        .HasConstraintName("FK_CHITIETGIOHANG_REFERENCE_THUCDON");
                });

            modelBuilder.Entity("CoffeeShopProject.Models.ChiTietHoaDon", b =>
                {
                    b.HasOne("CoffeeShopProject.Models.HoaDon", "MaHoaDonNavigation")
                        .WithMany("ChiTietHoaDon")
                        .HasForeignKey("MaHoaDon")
                        .HasConstraintName("FK_CHITIETH_REFERENCE_HOADON");

                    b.HasOne("CoffeeShopProject.Models.ThucDon", "MaThucDonNavigation")
                        .WithMany("ChiTietHoaDon")
                        .HasForeignKey("MaThucDon")
                        .HasConstraintName("FK_CHITIETH_REFERENCE_THUCDON");
                });

            modelBuilder.Entity("CoffeeShopProject.Models.GioHang", b =>
                {
                    b.HasOne("CoffeeShopProject.Models.KhachHang", "MaKhachHangNavigation")
                        .WithMany("GioHang")
                        .HasForeignKey("MaKhachHang")
                        .HasConstraintName("FK_GIOHANG_REFERENCE_KHACHHANG");
                });

            modelBuilder.Entity("CoffeeShopProject.Models.HoaDon", b =>
                {
                    b.HasOne("CoffeeShopProject.Models.BanAn", "MaBanNavigation")
                        .WithMany("HoaDon")
                        .HasForeignKey("MaBan")
                        .HasConstraintName("FK_HOADON_REFERENCE_BANAN");

                    b.HasOne("CoffeeShopProject.Models.NhanVien", "MaNhanVienNavigation")
                        .WithMany("HoaDon")
                        .HasForeignKey("MaNhanVien")
                        .HasConstraintName("FK_HOADON_REFERENCE_NHANVIEN");
                });

            modelBuilder.Entity("CoffeeShopProject.Models.KhachHang", b =>
                {
                    b.HasOne("CoffeeShopProject.Models.TaiKhoan", "MaTaiKhoanNavigation")
                        .WithMany("KhachHang")
                        .HasForeignKey("MaTaiKhoan")
                        .HasConstraintName("FK_KHACHHANG_REFERENCE_TAIKHOAN");
                });

            modelBuilder.Entity("CoffeeShopProject.Models.NhanVien", b =>
                {
                    b.HasOne("CoffeeShopProject.Models.ChucVu", "MaChucVuNavigation")
                        .WithMany("NhanVien")
                        .HasForeignKey("MaChucVu")
                        .HasConstraintName("FK_NHANVIEN_REFERENCE_CHUCVU");

                    b.HasOne("CoffeeShopProject.Models.TaiKhoan", "MaTaiKhoanNavigation")
                        .WithMany("NhanVien")
                        .HasForeignKey("MaTaiKhoan")
                        .HasConstraintName("FK_NHANVIEN_REFERENCE_TAIKHOAN");
                });

            modelBuilder.Entity("CoffeeShopProject.Models.PhanCong", b =>
                {
                    b.HasOne("CoffeeShopProject.Models.BanAn", "MaBanNavigation")
                        .WithMany("PhanCong")
                        .HasForeignKey("MaBan")
                        .HasConstraintName("FK_PHANCONG_REFERENCE_BANAN");
                });

            modelBuilder.Entity("CoffeeShopProject.Models.TaiKhoan", b =>
                {
                    b.HasOne("CoffeeShopProject.Models.PhanQuyen", "MaPhanQuyenNavigation")
                        .WithMany("TaiKhoan")
                        .HasForeignKey("MaPhanQuyen")
                        .HasConstraintName("FK_TAIKHOAN_REFERENCE_PHANQUYEN");
                });

            modelBuilder.Entity("CoffeeShopProject.Models.ThucDon", b =>
                {
                    b.HasOne("CoffeeShopProject.Models.LoaiThucDon", "MaLoaiNavigation")
                        .WithMany("ThucDon")
                        .HasForeignKey("MaLoai")
                        .HasConstraintName("FK_THUCDON_REFERENCE_LOAITHUC");
                });
#pragma warning restore 612, 618
        }
    }
}
