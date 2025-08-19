CREATE DATABASE KT0720_61654321
GO
USE KT0720_61654321
GO
CREATE TABLE Lop
(
  MaLop nvarchar(12) PRIMARY KEY,
  TenLop nvarchar(50)
 )
GO
CREATE TABLE SinhVien
(
	MaSV char(8) PRIMARY KEY,
	HoSV nvarchar(50),
	TenSV nvarchar(15),
	GioiTinh bit,
	NgaySinh date,
	AnhSV nvarchar(100),
	DiaChi nvarchar(100),
	MaLop nvarchar(12) FOREIGN KEY REFERENCES Lop(MaLop)
	ON UPDATE CASCADE
	ON DELETE CASCADE
)
GO
INSERT INTO Lop VALUES ('61.CNTT-CLC',N'Lớp CNTT chất lượng cao - Khóa 61'),('61.CNTT-1',N'Lớp CNTT 1 Chương trình chuẩn - Khóa 61')
GO
INSERT INTO SinhVien VALUES('61654321',N'Bùi Chí',N'Thành',1,'01/01/2000',NULL,N'Khánh Hòa','61.CNTT-CLC')