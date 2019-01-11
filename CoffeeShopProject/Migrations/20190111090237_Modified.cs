using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoffeeShopProject.Migrations
{
    public partial class Modified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BanAn",
                columns: table => new
                {
                    maBan = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    soGhe = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BanAn", x => x.maBan);
                });

            migrationBuilder.CreateTable(
                name: "Coupon",
                columns: table => new
                {
                    maCoupon = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    maNhap = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    giaKhuyenMai = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupon", x => x.maCoupon)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "ChucVu",
                columns: table => new
                {
                    maChucVu = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    tenChucVu = table.Column<string>(maxLength: 254, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChucVu", x => x.maChucVu)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "DanhGia",
                columns: table => new
                {
                    maDanhGia = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    maTaiKhoan = table.Column<int>(nullable: true),
                    maThucDon = table.Column<int>(nullable: true),
                    loiNhanXet = table.Column<string>(type: "ntext", nullable: true),
                    ngayDanhGia = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhGia", x => x.maDanhGia);
                });

            migrationBuilder.CreateTable(
                name: "LoaiThucDon",
                columns: table => new
                {
                    maLoai = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    tenLoai = table.Column<string>(maxLength: 254, nullable: true),
                    maLoaiCha = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiThucDon", x => x.maLoai)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "NgThamGia",
                columns: table => new
                {
                    maNgThamGia = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    maTaiKhoan = table.Column<int>(nullable: false),
                    maPhongChat = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NgThamGia", x => x.maNgThamGia);
                });

            migrationBuilder.CreateTable(
                name: "PhanQuyen",
                columns: table => new
                {
                    maPhanQuyen = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    quyenHan = table.Column<string>(maxLength: 254, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhanQuyen", x => x.maPhanQuyen)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "PhongChat",
                columns: table => new
                {
                    maPhongChat = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    tenPhongChat = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhongChat", x => x.maPhongChat);
                });

            migrationBuilder.CreateTable(
                name: "TinNhan",
                columns: table => new
                {
                    maTinNhan = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    maPhongChat = table.Column<int>(nullable: true),
                    maTaiKhoan = table.Column<int>(nullable: true),
                    tinNhan = table.Column<string>(type: "ntext", nullable: true),
                    ngayTao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TinNhan", x => x.maTinNhan);
                });

            migrationBuilder.CreateTable(
                name: "TinhThanh",
                columns: table => new
                {
                    maTinhThanh = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    tenTinhThanh = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TinhThanh", x => x.maTinhThanh);
                });

            migrationBuilder.CreateTable(
                name: "PhanCong",
                columns: table => new
                {
                    maPhanCong = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    maNhanVien = table.Column<int>(nullable: true),
                    maBan = table.Column<int>(nullable: true),
                    ca = table.Column<int>(nullable: true),
                    ngayPhanCong = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhanCong", x => x.maPhanCong)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_PHANCONG_REFERENCE_BANAN",
                        column: x => x.maBan,
                        principalTable: "BanAn",
                        principalColumn: "maBan",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ThucDon",
                columns: table => new
                {
                    maThucDon = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    tenThucDon = table.Column<string>(maxLength: 254, nullable: true),
                    hinhAnh = table.Column<string>(maxLength: 254, nullable: true),
                    maLoai = table.Column<int>(nullable: true),
                    gia = table.Column<double>(nullable: true),
                    khuyenMai = table.Column<int>(nullable: true),
                    moTa = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThucDon", x => x.maThucDon)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_THUCDON_REFERENCE_LOAITHUC",
                        column: x => x.maLoai,
                        principalTable: "LoaiThucDon",
                        principalColumn: "maLoai",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TaiKhoan",
                columns: table => new
                {
                    maTaiKhoan = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    tenTaiKhoan = table.Column<string>(maxLength: 254, nullable: false),
                    matKhau = table.Column<string>(maxLength: 254, nullable: false),
                    maPhanQuyen = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    email = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    anhDaiDien = table.Column<string>(maxLength: 254, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiKhoan", x => x.maTaiKhoan)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_TAIKHOAN_REFERENCE_PHANQUYEN",
                        column: x => x.maPhanQuyen,
                        principalTable: "PhanQuyen",
                        principalColumn: "maPhanQuyen",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KhachHang",
                columns: table => new
                {
                    maKhachHang = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    tenKhachHang = table.Column<string>(maxLength: 254, nullable: true),
                    email = table.Column<string>(maxLength: 254, nullable: true),
                    diaChi = table.Column<string>(maxLength: 254, nullable: true),
                    soDT = table.Column<string>(maxLength: 20, nullable: true),
                    maTaiKhoan = table.Column<int>(nullable: true),
                    maTinhThanh = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHang", x => x.maKhachHang)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_KHACHHANG_REFERENCE_TAIKHOAN",
                        column: x => x.maTaiKhoan,
                        principalTable: "TaiKhoan",
                        principalColumn: "maTaiKhoan",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NhanVien",
                columns: table => new
                {
                    maNhanVien = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CMND = table.Column<string>(maxLength: 20, nullable: true),
                    hinhAnh = table.Column<string>(maxLength: 254, nullable: true),
                    hoTen = table.Column<string>(maxLength: 254, nullable: true),
                    email = table.Column<string>(maxLength: 254, nullable: true),
                    luong = table.Column<double>(nullable: true),
                    moTa = table.Column<string>(type: "ntext", nullable: true),
                    maTaiKhoan = table.Column<int>(nullable: true),
                    maChucVu = table.Column<int>(nullable: true),
                    ngayBatDau = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanVien", x => x.maNhanVien)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_NHANVIEN_REFERENCE_CHUCVU",
                        column: x => x.maChucVu,
                        principalTable: "ChucVu",
                        principalColumn: "maChucVu",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NHANVIEN_REFERENCE_TAIKHOAN",
                        column: x => x.maTaiKhoan,
                        principalTable: "TaiKhoan",
                        principalColumn: "maTaiKhoan",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GioHang",
                columns: table => new
                {
                    maGioHang = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    maKhachHang = table.Column<int>(nullable: true),
                    tongCong = table.Column<double>(nullable: true),
                    ngayDat = table.Column<DateTime>(type: "datetime", nullable: true),
                    trangThai = table.Column<int>(nullable: true),
                    maTaiKhoan = table.Column<int>(nullable: true),
                    maCoupon = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GioHang", x => x.maGioHang)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_GIOHANG_REFERENCE_KHACHHANG",
                        column: x => x.maKhachHang,
                        principalTable: "KhachHang",
                        principalColumn: "maKhachHang",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HoaDon",
                columns: table => new
                {
                    maHoaDon = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    thoiGianLap = table.Column<DateTime>(type: "datetime", nullable: true),
                    soKhach = table.Column<int>(nullable: true),
                    maNhanVien = table.Column<int>(nullable: true),
                    maBan = table.Column<int>(nullable: true),
                    tongTien = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDon", x => x.maHoaDon)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_HOADON_REFERENCE_BANAN",
                        column: x => x.maBan,
                        principalTable: "BanAn",
                        principalColumn: "maBan",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HOADON_REFERENCE_NHANVIEN",
                        column: x => x.maNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "maNhanVien",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietGioHang",
                columns: table => new
                {
                    maCTGioHang = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    maGioHang = table.Column<int>(nullable: true),
                    maThucDon = table.Column<int>(nullable: true),
                    soLuong = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietGioHang", x => x.maCTGioHang)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_CHITIETGIOHANG_REFERENCE_GIOHANG",
                        column: x => x.maGioHang,
                        principalTable: "GioHang",
                        principalColumn: "maGioHang",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CHITIETGIOHANG_REFERENCE_THUCDON",
                        column: x => x.maThucDon,
                        principalTable: "ThucDon",
                        principalColumn: "maThucDon",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietHoaDon",
                columns: table => new
                {
                    maChiTiet = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    maHoaDon = table.Column<int>(nullable: true),
                    maThucDon = table.Column<int>(nullable: true),
                    soLuong = table.Column<int>(nullable: true),
                    donGia = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietHoaDon", x => x.maChiTiet);
                    table.ForeignKey(
                        name: "FK_CHITIETH_REFERENCE_HOADON",
                        column: x => x.maHoaDon,
                        principalTable: "HoaDon",
                        principalColumn: "maHoaDon",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CHITIETH_REFERENCE_THUCDON",
                        column: x => x.maThucDon,
                        principalTable: "ThucDon",
                        principalColumn: "maThucDon",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietGioHang_maGioHang",
                table: "ChiTietGioHang",
                column: "maGioHang");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietGioHang_maThucDon",
                table: "ChiTietGioHang",
                column: "maThucDon");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDon_maHoaDon",
                table: "ChiTietHoaDon",
                column: "maHoaDon");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDon_maThucDon",
                table: "ChiTietHoaDon",
                column: "maThucDon");

            migrationBuilder.CreateIndex(
                name: "IX_GioHang_maKhachHang",
                table: "GioHang",
                column: "maKhachHang");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_maBan",
                table: "HoaDon",
                column: "maBan");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_maNhanVien",
                table: "HoaDon",
                column: "maNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_KhachHang_maTaiKhoan",
                table: "KhachHang",
                column: "maTaiKhoan");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_maChucVu",
                table: "NhanVien",
                column: "maChucVu");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_maTaiKhoan",
                table: "NhanVien",
                column: "maTaiKhoan");

            migrationBuilder.CreateIndex(
                name: "IX_PhanCong_maBan",
                table: "PhanCong",
                column: "maBan");

            migrationBuilder.CreateIndex(
                name: "IX_TaiKhoan_maPhanQuyen",
                table: "TaiKhoan",
                column: "maPhanQuyen");

            migrationBuilder.CreateIndex(
                name: "IX_ThucDon_maLoai",
                table: "ThucDon",
                column: "maLoai");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coupon");

            migrationBuilder.DropTable(
                name: "ChiTietGioHang");

            migrationBuilder.DropTable(
                name: "ChiTietHoaDon");

            migrationBuilder.DropTable(
                name: "DanhGia");

            migrationBuilder.DropTable(
                name: "NgThamGia");

            migrationBuilder.DropTable(
                name: "PhanCong");

            migrationBuilder.DropTable(
                name: "PhongChat");

            migrationBuilder.DropTable(
                name: "TinNhan");

            migrationBuilder.DropTable(
                name: "TinhThanh");

            migrationBuilder.DropTable(
                name: "GioHang");

            migrationBuilder.DropTable(
                name: "HoaDon");

            migrationBuilder.DropTable(
                name: "ThucDon");

            migrationBuilder.DropTable(
                name: "KhachHang");

            migrationBuilder.DropTable(
                name: "BanAn");

            migrationBuilder.DropTable(
                name: "NhanVien");

            migrationBuilder.DropTable(
                name: "LoaiThucDon");

            migrationBuilder.DropTable(
                name: "ChucVu");

            migrationBuilder.DropTable(
                name: "TaiKhoan");

            migrationBuilder.DropTable(
                name: "PhanQuyen");
        }
    }
}
