USE [QLCHUNGCU]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 6/7/2024 8:46:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CanHo]    Script Date: 6/7/2024 8:46:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CanHo](
	[IdCanHo] [int] IDENTITY(1,1) NOT NULL,
	[SoCanHo] [nvarchar](max) NOT NULL,
	[Tang] [nvarchar](max) NOT NULL,
	[DienTich] [nvarchar](max) NOT NULL,
	[LoaiCanHo] [nvarchar](max) NOT NULL,
	[TinhTrang] [nvarchar](max) NOT NULL,
	[IdDanCu] [int] NOT NULL,
	[IdHopDong] [int] NOT NULL,
 CONSTRAINT [PK_CanHo] PRIMARY KEY CLUSTERED 
(
	[IdCanHo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DanCu]    Script Date: 6/7/2024 8:46:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanCu](
	[IdDanCu] [int] IDENTITY(1,1) NOT NULL,
	[HoTen] [nvarchar](max) NOT NULL,
	[NgaySinh] [datetime2](7) NOT NULL,
	[GioiTinh] [nvarchar](max) NOT NULL,
	[Sdt] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[DiaChi] [nvarchar](max) NOT NULL,
	[VaiTro] [nvarchar](max) NOT NULL,
	[IdCanHo] [int] NOT NULL,
 CONSTRAINT [PK_DanCu] PRIMARY KEY CLUSTERED 
(
	[IdDanCu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HopDong]    Script Date: 6/7/2024 8:46:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HopDong](
	[IdHopDong] [int] IDENTITY(1,1) NOT NULL,
	[IdCanHo] [int] NOT NULL,
	[IdDanCu] [int] NOT NULL,
	[IdNhanVien] [int] NOT NULL,
	[NgayTao] [datetime2](7) NOT NULL,
	[NgayBatDau] [datetime2](7) NOT NULL,
	[NgayKetThuc] [datetime2](7) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_HopDong] PRIMARY KEY CLUSTERED 
(
	[IdHopDong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 6/7/2024 8:46:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[IdNhanVien] [int] IDENTITY(1,1) NOT NULL,
	[TenNhanVien] [nvarchar](max) NOT NULL,
	[GioiTinh] [nvarchar](max) NOT NULL,
	[NgaySinh] [datetime2](7) NOT NULL,
	[Sdt] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[DiaChi] [nvarchar](max) NOT NULL,
	[IdTaiKhoan] [int] NOT NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[IdNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SuCo]    Script Date: 6/7/2024 8:46:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SuCo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdCanHo] [int] NOT NULL,
	[MoTaSuCo] [nvarchar](max) NOT NULL,
	[NgayBaoCao] [datetime2](7) NOT NULL,
	[TrangThai] [nvarchar](max) NOT NULL,
	[IdNhanVien] [int] NOT NULL,
 CONSTRAINT [PK_SuCo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 6/7/2024 8:46:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[IdTaiKhoan] [int] IDENTITY(1,1) NOT NULL,
	[TenDangNhap] [nvarchar](max) NOT NULL,
	[MatKhau] [nvarchar](max) NOT NULL,
	[VaiTro] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_TaiKhoan] PRIMARY KEY CLUSTERED 
(
	[IdTaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThongBao]    Script Date: 6/7/2024 8:46:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThongBao](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TieuDe] [nvarchar](max) NOT NULL,
	[NoiDung] [nvarchar](max) NOT NULL,
	[NgayGui] [nvarchar](max) NOT NULL,
	[IdNguoiGui] [int] NOT NULL,
	[IdNguoiNhan] [int] NOT NULL,
 CONSTRAINT [PK_ThongBao] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThuPhi]    Script Date: 6/7/2024 8:46:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThuPhi](
	[IdThuPhi] [int] IDENTITY(1,1) NOT NULL,
	[IdDanCu] [int] NOT NULL,
	[ThoiGian] [nvarchar](max) NOT NULL,
	[PhiQuanLy] [float] NOT NULL,
	[PhiDien] [float] NOT NULL,
	[PhiNuoc] [float] NOT NULL,
	[PhiDichVu] [float] NOT NULL,
	[PhiGuiXe] [float] NOT NULL,
	[NgayTao] [datetime2](7) NOT NULL,
	[TrangThai] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_ThuPhi] PRIMARY KEY CLUSTERED 
(
	[IdThuPhi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TienIch]    Script Date: 6/7/2024 8:46:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TienIch](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TenTienIch] [nvarchar](max) NOT NULL,
	[Vitri] [nvarchar](max) NOT NULL,
	[GioMoCua] [datetime2](7) NOT NULL,
	[IdNhanVien] [int] NOT NULL,
 CONSTRAINT [PK_TienIch] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE dbo.CanHo
ADD CONSTRAINT FK_CanHo_DanCu FOREIGN KEY (IdDanCu)
REFERENCES dbo.DanCu(IdDanCu);

ALTER TABLE dbo.CanHo
ADD CONSTRAINT FK_CanHo_HopDong FOREIGN KEY (IdHopDong)
REFERENCES dbo.HopDong(IdHopDong);

ALTER TABLE dbo.NhanVien
ADD CONSTRAINT FK_NhanVien_TaiKhoan FOREIGN KEY (IdTaiKhoan)
REFERENCES dbo.TaiKhoan(IdTaiKhoan);

GO
SET IDENTITY_INSERT CanHo OFF;
SET IDENTITY_INSERT DanCu OFF;
SET IDENTITY_INSERT HopDong OFF;
SET IDENTITY_INSERT NhanVien OFF;
SET IDENTITY_INSERT SuCo OFF;
SET IDENTITY_INSERT TaiKhoan OFF;
SET IDENTITY_INSERT ThongBao OFF;
SET IDENTITY_INSERT ThuPhi OFF;
SET IDENTITY_INSERT TienIch OFF;

