/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2012                    */
/* Created on:     30/11/2018 8:52:02 CH                        */
/*==============================================================*/

/*==============================================================*/
/* Table: BanAn                                                 */
/*==============================================================*/
drop database CoffeeShop

create database CoffeeShop
go
use CoffeeShop

create table BanAn (
   maBan                int      identity(1,1)            not null,
   soGhe                int                  null,
   constraint PK_BANAN primary key (maBan)
)
go

/*==============================================================*/
/* Table: ChiTietHoaDon                                         */
/*==============================================================*/
create table ChiTietHoaDon (
   maChiTiet    		int      identity(1,1)            not null,
   maHoaDon             int                  null,
   maThucDon            int                  null,
   soLuong              int                  null,
   donGia               float                null
    constraint PK_CHITIETHOADON primary key (maChiTiet)
)
go

/*==============================================================*/
/* Table: HoaDon                                                */
/*==============================================================*/
create table HoaDon (
   maHoaDon             int      identity(1,1)            not null,
   thoiGianLap          datetime             null,
   soKhach              int                  null,
   maNhanVien           int                  null,
   maBan                int                  null,
   tongTien             float                null,
   constraint PK_HOADON primary key nonclustered (maHoaDon)
)
go

/*==============================================================*/
/* Table: LoaiThucDon                                           */
/*==============================================================*/
create table LoaiThucDon (
   maLoai               int      identity(1,1),
   tenLoai              nvarchar(254)         null,
   constraint PK_LOAITHUCDON primary key nonclustered (maLoai)
)

go

/*==============================================================*/
/* Table: NhanVien                                              */
/*==============================================================*/
create table NhanVien (
   maNhanVien          int      identity(1,1)            not null,
   hoTen                nvarchar(254)         null,
   ngaySinh             datetime             null,
   tenDangNhap          nvarchar(254)         null,
   matKhau              nvarchar(254)         null,
   chucVu               nvarchar(254)         null,
   constraint PK_NHANVIEN primary key nonclustered (maNhanVien)
)
go

/*==============================================================*/
/* Table: PhanCong                                              */
/*==============================================================*/
create table PhanCong (
   maPhanCong			int      identity(1,1)            not null,
   maNhanVien           int                  null,
   maBan                int                  null,
   ca                   int                  null,
   ngayPhanCong         datetime             null
   constraint PK_PHANCONG primary key nonclustered (maPhanCong)
)
go

/*==============================================================*/
/* Table: ThucDon                                               */
/*==============================================================*/
create table ThucDon (
   maThucDon            int identity(1,1) not null,
   tenThucDon           nvarchar(254)         null,
   hinhAnh              nvarchar(254)         null,
   maLoai               int                  null,
   gia					float				 null,
   khuyenMai			int					 null,
   constraint PK_THUCDON primary key nonclustered (maThucDon)
)
go
/*==============================================================*/
/* Table: KhachHang                                               */
/*==============================================================*/
create table KhachHang (
   maKhachHang            int identity(1,1) not null,
   tenKhachHang           nvarchar(254)         null,
   email              nvarchar(254)         null,
   diaChi               nvarchar(254)          null,
   tinhThanh			nvarchar(254)		 null,
   soDT			nvarchar(20)					 null,
   constraint PK_KHACHHANG primary key nonclustered (maKhachHang)
)
go
/*==============================================================*/
/* Table: GioHang                                             */
/*==============================================================*/
create table GioHang (
   maGioHang            int identity(1,1) not null,
   maKhachHang          int        null,
   tongCong				float	   null,
   ngayDat				datetime   null,
   trangThai			int		   null,
   constraint PK_GIOHANG primary key nonclustered (maGioHang)
)
go
/*==============================================================*/
/* Table: ChiTietGioHang                                            */
/*==============================================================*/
create table ChiTietGioHang (
   maCTGioHang           int identity(1,1) not null,
   maGioHang			int		null,
   maThucDon          int        null,
   soLuong				int	   null,
   constraint PK_CHITIETGIOHANG primary key nonclustered (maCTGioHang)
)
go

alter table ChiTietHoaDon
   add constraint FK_CHITIETH_REFERENCE_THUCDON foreign key (maThucDon)
      references ThucDon (maThucDon)
go

alter table ChiTietHoaDon
   add constraint FK_CHITIETH_REFERENCE_HOADON foreign key (maHoaDon)
      references HoaDon (maHoaDon)
go

alter table HoaDon
   add constraint FK_HOADON_REFERENCE_NHANVIEN foreign key (maNhanVien)
      references NhanVien (maNhanVien)
go

alter table HoaDon
   add constraint FK_HOADON_REFERENCE_BANAN foreign key (maBan)
      references BanAn (maBan)
go

 

alter table PhanCong
   add constraint FK_PHANCONG_REFERENCE_BANAN foreign key (maBan)
      references BanAn (maBan)
go

alter table ThucDon
   add constraint FK_THUCDON_REFERENCE_LOAITHUC foreign key (maLoai)
      references LoaiThucDon (maLoai)
go

alter table ChiTietGioHang
   add constraint FK_CHITIETGIOHANG_REFERENCE_GIOHANG foreign key (maGioHang)
      references GioHang (maGioHang)
go
alter table ChiTietGioHang
   add constraint FK_CHITIETGIOHANG_REFERENCE_THUCDON foreign key (maThucDon)
      references ThucDon (maThucDon)
go

alter table GioHang
   add constraint FK_GIOHANG_REFERENCE_KHACHHANG foreign key (maKhachHang)
      references KhachHang (maKhachHang)
go

INSERT INTO LoaiThucDon VALUES ('Coffee');
go
INSERT INTO LoaiThucDon VALUES ('Freeze');
go

INSERT INTO ThucDon VALUES (N'Cappuchino', 'cappuccino_PNG26.png', 16, 15, 0);
go
INSERT INTO ThucDon VALUES (N'Latte', 'ABC.jpg', 16, 12.5, 0);

select * from LoaiThucDon

delete from ThucDon

delete from LoaiThucDon