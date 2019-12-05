using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CoffeeShopProject.Models
{
    public partial class CoffeeShopContext : DbContext
    {
        public static String SERVER_NAME = "DESKTOP-8N26TO5\\SQLEXPRESS";
        public CoffeeShopContext()
        {
        }

        public CoffeeShopContext(DbContextOptions<CoffeeShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BanAn> BanAn { get; set; }
        public virtual DbSet<Tang> Tang { get; set; }
        public virtual DbSet<Coupon> Coupon { get; set; }
        public virtual DbSet<ChiTietGioHang> ChiTietGioHang { get; set; }
        public virtual DbSet<ChiTietHoaDon> ChiTietHoaDon { get; set; }
        public virtual DbSet<ChucVu> ChucVu { get; set; }
        public virtual DbSet<DanhGia> DanhGia { get; set; }
        public virtual DbSet<GioHang> GioHang { get; set; }
        public virtual DbSet<HoaDon> HoaDon { get; set; }
        public virtual DbSet<HoaDonX> HoaDonX { get; set; }
        public virtual DbSet<KhachHang> KhachHang { get; set; }
        public virtual DbSet<LoaiThucDon> LoaiThucDon { get; set; }
        public virtual DbSet<NgThamGia> NgThamGia { get; set; }
        public virtual DbSet<NhanVien> NhanVien { get; set; }
        public virtual DbSet<PhanCong> PhanCong { get; set; }
        public virtual DbSet<PhanQuyen> PhanQuyen { get; set; }
        public virtual DbSet<PhongChat> PhongChat { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoan { get; set; }
        public virtual DbSet<TinNhan> TinNhan { get; set; }
        public virtual DbSet<TinhThanh> TinhThanh { get; set; }
        public virtual DbSet<ThucDon> ThucDon { get; set; }
        public virtual DbSet<PushDevice> PushDevice { get; set; }
        public virtual DbSet<PostLog> PostLog { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                // optionsBuilder.UseSqlServer("workstation id=TLECoffeeDB.mssql.somee.com;packet size=4096;user id=anhquoc4062_SQLLogin_1;pwd=9o25twlvdp;data source=TLECoffeeDB.mssql.somee.com;persist security info=False;initial catalog=TLECoffeeDB");
                optionsBuilder.UseSqlServer("Server=.; Database=CoffeeShop; Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BanAn>(entity =>
            {
                entity.HasKey(e => e.MaBan);

                entity.Property(e => e.MaBan).HasColumnName("maBan");

                entity.Property(e => e.TenBan).HasColumnName("tenBan");

                entity.Property(e => e.MaTang).HasColumnName("maTang");
            });

            modelBuilder.Entity<Tang>(entity =>
            {
                entity.HasKey(e => e.MaTang);

                entity.Property(e => e.MaTang).HasColumnName("maTang");

                entity.Property(e => e.TenTang).HasColumnName("tenTang");
            });

            modelBuilder.Entity<Coupon>(entity =>
            {
                entity.HasKey(e => e.MaCoupon);

                entity.Property(e => e.MaCoupon).HasColumnName("maCoupon");

                entity.Property(e => e.GiaKhuyenMai).HasColumnName("giaKhuyenMai");

                entity.Property(e => e.MaNhap)
                    .HasColumnName("maNhap")
                    .HasMaxLength(50);
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

                //entity.HasOne(d => d.MaThucDonNavigation)
                    //.HasForeignKey(d => d.MaThucDon)
                    //.HasConstraintName("FK_CHITIETGIOHANG_REFERENCE_THUCDON");
            });

            modelBuilder.Entity<ChiTietHoaDon>(entity =>
            {
                entity.HasKey(e => e.MaChiTiet);

                entity.Property(e => e.MaChiTiet).HasColumnName("maChiTiet");

                entity.Property(e => e.DonGia).HasColumnName("donGia");

                entity.Property(e => e.MaHoaDon).HasColumnName("maHoaDon");
                entity.Property(e => e.MaHoaDonLocal).HasColumnName("maHoaDonLocal");

                entity.Property(e => e.MaThucDon).HasColumnName("maThucDon");

                entity.Property(e => e.SoLuong).HasColumnName("soLuong");

                entity.Property(e => e.MaChiTietLocal).HasColumnName("maChiTietLocal");

                entity.Property(e => e.TrangThai).HasColumnName("trangThai");

                //entity.HasOne(d => d.MaHoaDonNavigation)
                //    .WithMany(p => p.ChiTietHoaDon)
                //    .HasForeignKey(d => d.MaHoaDon)
                //    .HasConstraintName("FK_CHITIETH_REFERENCE_HOADON");

                //entity.HasOne(d => d.MaThucDonNavigation)
                //    //.HasForeignKey(d => d.MaThucDon)
                //    .HasConstraintName("FK_CHITIETH_REFERENCE_THUCDON");
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
                entity.HasKey(e => e.MaHoaDon);

                entity.Property(e => e.MaHoaDon).HasColumnName("maHoaDon");

                entity.Property(e => e.MaBan).HasColumnName("maBan");

                entity.Property(e => e.MaNhanVienOrder).HasColumnName("maNhanVienOrder");

                entity.Property(e => e.ThoiGianLap)
                    .HasColumnName("thoiGianLap")
                    .HasColumnType("datetime");

                entity.Property(e => e.TongTien).HasColumnName("tongTien");

                entity.Property(e => e.MaHoaDonLocal).HasColumnName("maHoaDonLocal");

                entity.Property(e => e.TrangThai).HasColumnName("trangThai");
                entity.Property(e => e.GiamGia).HasColumnName("giamGia");
                entity.Property(e => e.ThanhTien).HasColumnName("thanhTien");
                entity.Property(e => e.MaThuNgan).HasColumnName("maThuNgan");

                //entity.HasOne(d => d.MaBanNavigation)
                //    .WithMany(p => p.HoaDon)
                //    .HasForeignKey(d => d.MaBan)
                //    .HasConstraintName("FK_HOADON_REFERENCE_BANAN");

                //entity.HasOne(d => d.MaNhanVienNavigation)
                //    .WithMany(p => p.HoaDon)
                //    .HasForeignKey(d => d.MaNhanVien)
                //    .HasConstraintName("FK_HOADON_REFERENCE_NHANVIEN");
            });

            modelBuilder.Entity<HoaDonX>(entity =>
            {
                entity.HasKey(e => e.MaHoaDon);

                entity.Property(e => e.MaHoaDon).HasColumnName("maHoaDon");

                entity.Property(e => e.MaBan).HasColumnName("maBan");

                entity.Property(e => e.MaNhanVienOrder).HasColumnName("maNhanVienOrder");

                entity.Property(e => e.ThoiGianLap)
                    .HasColumnName("thoiGianLap");

                entity.Property(e => e.TongTien).HasColumnName("tongTien");

                entity.Property(e => e.MaHoaDonLocal).HasColumnName("maHoaDonLocal");

                entity.Property(e => e.TrangThai).HasColumnName("trangThai");
                entity.Property(e => e.GiamGia).HasColumnName("giamGia");
                entity.Property(e => e.ThanhTien).HasColumnName("thanhTien");
                entity.Property(e => e.MaThuNgan).HasColumnName("maThuNgan");

                //entity.HasOne(d => d.MaBanNavigation)
                //    .WithMany(p => p.HoaDon)
                //    .HasForeignKey(d => d.MaBan)
                //    .HasConstraintName("FK_HOADON_REFERENCE_BANAN");

                //entity.HasOne(d => d.MaNhanVienNavigation)
                //    .WithMany(p => p.HoaDon)
                //    .HasForeignKey(d => d.MaNhanVien)
                //    .HasConstraintName("FK_HOADON_REFERENCE_NHANVIEN");
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

            modelBuilder.Entity<NgThamGia>(entity =>
            {
                entity.HasKey(e => e.MaNgThamGia);

                entity.Property(e => e.MaNgThamGia)
                    .HasColumnName("maNgThamGia")
                    .ValueGeneratedNever();

                entity.Property(e => e.MaPhongChat).HasColumnName("maPhongChat");

                entity.Property(e => e.MaTaiKhoan).HasColumnName("maTaiKhoan");
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

                //entity.HasOne(d => d.MaBanNavigation)
                //    .WithMany(p => p.PhanCong)
                //    .HasForeignKey(d => d.MaBan)
                //    .HasConstraintName("FK_PHANCONG_REFERENCE_BANAN");
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

            modelBuilder.Entity<PhongChat>(entity =>
            {
                entity.HasKey(e => e.MaPhongChat);

                entity.Property(e => e.MaPhongChat).HasColumnName("maPhongChat");

                entity.Property(e => e.TenPhongChat)
                    .HasColumnName("tenPhongChat")
                    .HasMaxLength(255);
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

                entity.Property(e => e.DangHoatDong)
                    .IsRequired()
                    .HasColumnName("dangHoatDong")
                    .HasMaxLength(254);

                entity.HasOne(d => d.MaPhanQuyenNavigation)
                    .WithMany(p => p.TaiKhoan)
                    .HasForeignKey(d => d.MaPhanQuyen)
                    .HasConstraintName("FK_TAIKHOAN_REFERENCE_PHANQUYEN");
            });

            modelBuilder.Entity<TinNhan>(entity =>
            {
                entity.HasKey(e => e.MaTinNhan);

                entity.Property(e => e.MaTinNhan).HasColumnName("maTinNhan");

                entity.Property(e => e.MaPhongChat).HasColumnName("maPhongChat");

                entity.Property(e => e.MaTaiKhoan).HasColumnName("maTaiKhoan");

                entity.Property(e => e.NgayTao)
                    .HasColumnName("ngayTao")
                    .HasColumnType("datetime");

                entity.Property(e => e.TinNhan1)
                    .HasColumnName("tinNhan1")
                    .HasMaxLength(255);

                entity.Property(e => e.TrangThai).HasColumnName("trangThai");
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
            });

            modelBuilder.Entity<PushDevice> (entity =>
            {
                entity.HasKey(e => e.PushID);
                entity.Property(e => e.PushID).HasColumnName("pushID");
                entity.Property(e => e.Token).HasColumnName("token");
            });


            modelBuilder.Entity<PostLog>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Api).HasColumnName("api");

                entity.Property(e => e.Params)
                    .HasColumnName("params");

                entity.Property(e => e.Response)
                    .HasColumnName("response");

                entity.Property(e => e.RegDate)
                    .HasColumnName("reg_date");

                entity.Property(e => e.LocalId)
                .HasColumnName("local_id");
            });
        }
    }
}
