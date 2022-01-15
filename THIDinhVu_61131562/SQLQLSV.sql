CREATE DATABASE THI_61131562
GO
USE THI_61131562
GO
CREATE TABLE Lop
(
  MaLop nvarchar(12) PRIMARY KEY,
  TenLop nvarchar(50) NOT NULL
 )
GO
CREATE TABLE NganhHoc
(
 MaNganh nvarchar(12) PRIMARY KEY,
 TenNganh nvarchar(50) NOT NULL
 )
GO
CREATE TABLE SinhVien
(
	MaSV char(8) PRIMARY KEY,
	HoSV nvarchar(50) NOT NULL,
	TenSV nvarchar(15) NOT NULL,
	GioiTinh bit DEFAULT(1),
	NgaySinh date,
	AnhSV nvarchar(100),
	DiaChi nvarchar(100) NOT NULL,
	TonGiao nvarchar(50) NOT NULL,
	DanToc nvarchar(50) NOT NULL,
	SDT nvarchar(12) NOT NULL,
	CMND nvarchar(10) NOT NULL,
	HeDT nvarchar(20) NOT NULL,
	HoTenCha nvarchar (69) NOT NULL,
	NgaySinhCha date,
	NgheNghiepCha nvarchar(50) NOT NULL,
	HoTenMe nvarchar (69) NOT NULL,
	NgaySinhMe date,
	NgheNghiepMe nvarchar(50) NOT NULL,
	Email nvarchar(50) NOT NULL,

	MaLop nvarchar(12) NOT NULL FOREIGN KEY REFERENCES Lop(MaLop),
	MaNganh nvarchar(12) NOT NULL FOREIGN KEY REFERENCES NganhHoc(MaNganh)
	ON UPDATE CASCADE
	ON DELETE CASCADE
)
GO
CREATE TABLE QuanTri
(
	Email varchar(50) PRIMARY KEY,
	Admin bit,
	HoTen nvarchar(50),
	Password nvarchar(50)
)
GO
INSERT INTO NganhHoc VALUES ('CNTT',N'Công nghệ thông tin'), ('NNA',N'Ngôn ngữ Anh'),('QTDL',N'Quản trị du lịch')
GO
INSERT INTO Lop VALUES ('61.CNTT-CLC',N'Lớp CNTT chất lượng cao - Khóa 61'),
('61.CNTT-2',N'Lớp CNTT 2 Chương trình chuẩn - Khóa 61'),
('61.NNA-4',N'Lớp Ngoại Ngữ 4 Chương trình chuẩn - Khóa 61'),
('62.CNTT-CLC',N'Lớp CNTT chất lượng cao - Khóa 62'),
('62.CNTT-2',N'Lớp CNTT 2 Chương trình chuẩn - Khóa 62'),
('62.NNA-6',N'Lớp Ngoại Ngữ 6 Chương trình chuẩn - Khóa 62'),
('60.QTDL-6',N'Lớp Quản trị du lịch - Khóa 60'),
('60.CNTT-2',N'Lớp CNTT 2 Chương trình chuẩn - Khóa 60'),
('60.NNA-4',N'Lớp Ngoại Ngữ 4 Chương trình chuẩn - Khóa 60')

GO
INSERT INTO QuanTri VALUES('dinhvu69@gmail.com',1,N'Phan Nguyễn Đình Vũ','6969')
GO
INSERT INTO SinhVien VALUES('61131562',N'Phan Nguyễn Đình',N'Vũ',1,CAST(N'2000-01-20' AS Date),NULL,N'Vạn Ninh, Khánh Hòa',N'Không',N'Kinh','0392592879','225625169',N'Đại học',N'Trần Văn A','01/01/1969',N'Giáo viên',N'Nguyễn Thị B','02/02/1996',N'Nội trợ','vu69@gmail.com','61.CNTT-CLC','CNTT')
INSERT INTO SinhVien VALUES('61131569',N'Nguyễn Thị Thanh',N'Ni',0,CAST(N'2001-03-04' AS Date),NULL,N'Hà Già, Khánh Hòa',N'Không',N'Kinh','0393920500','225625176',N'Đại học',N'Trần Văn B','02/02/1970',N'Công nhân',N'Nguyễn Thị C','03/03/1997',N'Nội trợ','ni96@gmail.com','61.NNA-4','NNA')
INSERT INTO SinhVien VALUES('61131563',N'Nguyễn Anh',N'Phương',1,CAST(N'2001-09-06' AS Date),NULL,N'Ninh Hòa, Khánh Hòa',N'Phật giáo',N'Kinh','0392592878','225625177',N'Đại học',N'Trần Văn F','06/09/1963',N'Thợ điện',N'Nguyễn Thị D','09/06/1989',N'Công nhân','phuong420@gmail.com','61.CNTT-2','CNTT')
INSERT INTO SinhVien VALUES('61131564',N'Trương Khàng',N'Đinh',1,CAST(N'2001-06-09' AS Date),NULL,N'Nha Trang, Khánh Hòa',N'Không',N'Kinh','0392592877','225625178',N'Đại học',N'Trần Văn D','04/04/1977',N'Thợ mộc',N'Nguyễn Thị L','05/05/1988',N'Nội trợ','khanglmao@gmail.com','62.CNTT-CLC','CNTT')
INSERT INTO SinhVien VALUES('61131565',N'Mai Đoàn Ánh',N'Như',0,CAST(N'2001-04-20' AS Date),NULL,N'Vạn Ninh, Khánh Hòa',N'Không',N'Kinh','0392592876','225625179',N'Đại học',N'Trần Văn G','04/02/1966',N'Kỹ sư',N'Nguyễn Thị P','02/04/1977',N'Giáo viên','nhunhu@gmail.com','60.QTDL-6','QTDL')
INSERT INTO SinhVien VALUES('61131566',N'Đặng Hải',N'Lựu',0,CAST(N'2002-11-01' AS Date),NULL,N'Nha Trang, Khánh Hòa',N'Hồi giáo',N'Kinh','0392592875','225625170',N'Cao Đẳng',N'Trần Văn L','01/01/1988',N'Phụ hộ',N'Nguyễn Thị F','11/11/1999',N'Nội trợ','daidu@gmail.com','62.NNA-6','NNA')
GO
CREATE PROCEDURE SinhVien_TimKiem
    @MaSV varchar(8)=NULL,
	@HoTen nvarchar(40)=NULL,
	@GioiTinh nvarchar(3)= NULL,
	@DiaChi nvarchar(70)=NULL,
	@MaLop nvarchar(12)=NULL
AS
BEGIN
DECLARE @SqlStr NVARCHAR(4000),
		@ParamList nvarchar(2000)
SELECT @SqlStr = '
       SELECT * 
       FROM SinhVien
       WHERE  (1=1)
       '
IF @MaSV IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (MaSV LIKE ''%'+@MaSV+'%'')
              '
IF @HoTen IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (HoSV+'' ''+TenSV LIKE ''%'+@HoTen+'%'')
              '
IF @GioiTinh IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
             AND (GioiTinh LIKE ''%'+@GioiTinh+'%'')
             '
IF @DiaChi IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (DiaChi LIKE ''%'+@DiaChi+'%'')
              '
IF @MaLop IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (MaLop LIKE ''%'+@MaLop+'%'')
              '
	EXEC SP_EXECUTESQL @SqlStr
END