/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2012                    */
/* Created on:     30/11/2018 8:52:02 CH                        */
/*==============================================================*/

/*==============================================================*/
/* Table: BanAn                                                 */
/*==============================================================*/

go
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
   CMND					nvarchar(20)		  null,
   hinhAnh				nvarchar(254)		  null,	
   hoTen                nvarchar(254)         null,
   email				nvarchar(20)	null,
   luong				  float		null,
   moTa					  ntext		null,
   maChucVu               int       null,
   maTaiKhoan			  int		null,
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
   moTa					ntext				 null,
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
/*==============================================================*/
/* Table: ChucVu                                           */
/*==============================================================*/
create table ChucVu(
	maChucVu		int identity(1,1) not null,
	tenChucVu		nvarchar(254)     null,
	constraint PK_CHUCVU primary key nonclustered (maChucVu)
)
/*==============================================================*/
/* Table: TaiKhoan                                           */
/*==============================================================*/
create table TaiKhoan(
	maTaiKhoan		int identity(1,1) not null,
	tenTaiKhoan		nvarchar(254)     not null,
	matKhau			nvarchar(254)	  not null,
	constraint PK_TAIKHOAN primary key nonclustered (maTaiKhoan)
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
alter table NhanVien
	add constraint FK_CHUCVU_REFERENCE_NHANVIEN foreign key (maChucVu)
      references ChucVu (maChucVu)
go
alter table NhanVien
	add constraint FK_TAIKHOAN_REFERENCE_NHANVIEN foreign key (maTaiKhoan)
      references TaiKhoan (maTaiKhoan)
go
INSERT INTO LoaiThucDon VALUES ('Coffee');
go
INSERT INTO LoaiThucDon VALUES ('Freeze');
go

INSERT INTO ThucDon VALUES (N'Cappuchino', 'cappuccino_PNG26.png', 1, 15, 0, N'mô tả đó nhé');
go
INSERT INTO ThucDon VALUES (N'Latte', 'ABC.jpg', 1, 12.5, 0, N'fsdfasd');
go

INSERT INTO ChucVu VALUES (N'Pha Chế');
go
INSERT INTO ChucVu VALUES (N'Phục Vụ');
go
INSERT INTO ChucVu VALUES (N'Thu Ngân');
go

INSERT INTO TaiKhoan VALUES ('nva123','123456');
go
INSERT INTO TaiKhoan VALUES ('ntb456','654321');
go

INSERT INTO NhanVien VALUES ('123456', 'example.jpg', N'Nguyễn Văn A', 'abc@gmail.com', 50, N'mô tả đó nhé', 1, 1);
go
INSERT INTO NhanVien VALUES ('789321', 'example.jpg', N'Nguyễn Thị B', 'def@gmail.com', 40, N'mô tả của nhân viên', 2, 2);


select * from NhanVien