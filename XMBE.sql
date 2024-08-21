
use master
drop database XMBE

CREATE DATABASE XMBE;

USE XMBE;

CREATE TABLE [User]
(
	[id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
    [name] NVARCHAR(100) NOT NULL,
    [username] NVARCHAR(50) NOT NULL UNIQUE,
    [password] NVARCHAR(255) NOT NULL,
    [role] NVARCHAR(50) NOT NULL
)
INSERT INTO [User] ([id], [name], [username], [password], [role])
VALUES 
    (NEWID(), 'Son Tung', 'admin', '123', 'Admin'),
    (NEWID(), 'Phuong Hang', 'manager', '123', 'Manager'),
    (NEWID(), 'Truong My Lan', 'admin2', '12345', 'Admin'),
    (NEWID(), 'Le Roi', 'manager2', '12345', 'Manager');

CREATE TABLE DANHMUC
(
	MADM INT PRIMARY KEY,
	TENDM NVARCHAR(50) NOT NULL
)
CREATE TABLE SANPHAM
(
	MASP INT PRIMARY KEY,
	MADM INT,
	TENSP NVARCHAR(MAX) NOT NULL,
	GiaBan money,
	MOTA TEXT,
	SoLuongCon int,
	XuatXu char(50),
	CONSTRAINT FK_DM_FR_SP FOREIGN KEY(MADM) REFERENCES DANHMUC
)
CREATE TABLE CHUYEN
(
	MACHUYEN INT PRIMARY KEY,
	SOCN INT,
	NHIEMVU NVARCHAR(50),
	VITRI CHAR(2)
)
CREATE TABLE DONHANG
(
	MADON INT PRIMARY KEY,
	NGAYDAT DATE,
	SOLUONG INT,
	MASP INT,
	CONSTRAINT FK_SP_FR_DH FOREIGN KEY (MASP) REFERENCES SANPHAM(MASP)
)
insert into donhang values(90,getdate(), 13, 1)
CREATE TABLE CONGVIEC
(
	MACV INT PRIMARY KEY,
	MACHUYEN INT,
	MADH INT,
	SOLUONG INT,
	TENCV NVARCHAR(50),
	THOIGIAN NCHAR(10),
	CONSTRAINT FK_DH_FR_CV FOREIGN KEY (MADH) REFERENCES DONHANG(MADON)
   ,CONSTRAINT FK_CHUYEN_FR_CV FOREIGN KEY (MACHUYEN) REFERENCES CHUYEN(MACHUYEN)
)
select *from donhang
insert into danhmuc values(1,N'Áo'),(2,N'Quần dài'),(3,N'Váy')

insert into sanpham values(1,1, N'Áo thun nam XXL',300000,N'Áo thun hottrend toptop phù hợp với nam đang hẹn hò',300,N'China')
insert into sanpham values(2,2, N'Quần nam XXL',300000,N'Quần hottrend toptop phù hợp với nam đang hẹn hò',300,N'China')
go
-- Trigger để cập nhật số lượng sản phẩm khi thêm đơn hàng
CREATE TRIGGER trg_after_insert_donhang
ON donhang
AFTER INSERT
AS
BEGIN
    -- Cập nhật số lượng sản phẩm sau khi thêm đơn hàng
    UPDATE sanpham
    SET soluongcon = soluong - i.soluong
    FROM sanpham s
    INNER JOIN inserted i ON s.masp = i.masp
END
GO

-- Trigger để cập nhật số lượng sản phẩm khi xóa đơn hàng
CREATE TRIGGER trg_after_delete_donhang
ON donhang
AFTER DELETE
AS
BEGIN
    -- Cập nhật số lượng sản phẩm sau khi xóa đơn hàng
    UPDATE sanpham
    SET soluongcon = soluong + d.soluong
    FROM sanpham s
    INNER JOIN deleted d ON s.masp = d.masp
END
GO
