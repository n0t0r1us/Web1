CREATE DATABASE Thi_61131562
GO
USE Thi_61131562
GO
CREATE TABLE LoaiDocGia
(
  MaLoaiDocGia nvarchar(12) PRIMARY KEY,
  TenLoaiDocGia nvarchar(50)
 )
GO
CREATE TABLE DocGia
(
	MaDG char(8) PRIMARY KEY,
	HoDG nvarchar(50),
	TenDG nvarchar(15),
	NgaySinh date,
	GioiTinh bit,
	Email nvarchar(100),
	AnhDG nvarchar(100),
	MaLoaiDocGia nvarchar(12) FOREIGN KEY REFERENCES LoaiDocGia(MaLoaiDocGia)
	ON UPDATE CASCADE
	ON DELETE CASCADE
)
GO
INSERT INTO LoaiDocGia VALUES ('100',N'Độc Giả Trẻ'),(N'101',N'Độc Giả Già'),(N'102',N'Độc Giả')
GO
INSERT INTO DocGia VALUES('001',N'Phan',N'Nguyễn Đình Vũ','01/20/2001',1,'chithien2525@gmail.com',NULL,'100')
INSERT INTO DocGia VALUES('002',N'Nguyễn',N'Anh Phương','02/21/2002',1,'anhphuong@gmail.com',NULL,'101')
INSERT INTO DocGia VALUES('003',N'Trương',N'Đình Khang','03/22/2000',0,'chithien2525@gmail.com',NULL,'102')