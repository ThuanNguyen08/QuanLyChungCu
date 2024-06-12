using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyChungCu.Migrations
{
    /// <inheritdoc />
    public partial class QlChungCu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DanCu",
                columns: table => new
                {
                    IdDanCu = table.Column<int>(type: "int", nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GioiTinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sdt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VaiTro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCanHo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanCu", x => x.IdDanCu);
                });

            migrationBuilder.CreateTable(
                name: "HopDong",
                columns: table => new
                {
                    IdHopDong = table.Column<int>(type: "int", nullable: false),
                    IdCanHo = table.Column<int>(type: "int", nullable: false),
                    IdDanCu = table.Column<int>(type: "int", nullable: false),
                    IdNhanVien = table.Column<int>(type: "int", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HopDong", x => x.IdHopDong);
                });

            migrationBuilder.CreateTable(
                name: "CanHo",
                columns: table => new
                {
                    IdCanHo = table.Column<int>(type: "int", nullable: false),
                    SoCanHo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DienTich = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoaiCanHo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TinhTrang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdDanCu = table.Column<int>(type: "int", nullable: false),
                    IdHopDong = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CanHo", x => x.IdCanHo);
                    table.ForeignKey(
                        name: "FK_CanHo_DanCu_IdDanCu",
                        column: x => x.IdDanCu,
                        principalTable: "DanCu",
                        principalColumn: "IdDanCu",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CanHo_HopDong_IdHopDong",
                        column: x => x.IdHopDong,
                        principalTable: "HopDong",
                        principalColumn: "IdHopDong",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.Sql(
                     @"
                        CREATE TRIGGER update_canho_tinhtrang
                        ON DanCu
                        AFTER DELETE
                        AS
                        BEGIN
                            SET NOCOUNT ON;

                            UPDATE CanHo
                            SET TinhTrang = 'trống'
                            FROM CanHo c
                            INNER JOIN deleted d ON c.IdCanHo = d.IdCanHo
                        END;
                     "
                );
                
            migrationBuilder.CreateTable(
                name: "SuCo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    IdCanHo = table.Column<int>(type: "int", nullable: false),
                    MoTaSuCo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayBaoCao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdNhanVien = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuCo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaiKhoan",
                columns: table => new
                {
                    IdTaiKhoan = table.Column<int>(type: "int", nullable: false),
                    TenDangNhap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VaiTro = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiKhoan", x => x.IdTaiKhoan);
                });

            migrationBuilder.CreateTable(
                name: "NhanVien",
                columns: table => new
                {
                    IdNhanVien = table.Column<int>(type: "int", nullable: false),
                    TenNhanVien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GioiTinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sdt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdTaiKhoan = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanVien", x => x.IdNhanVien);
                    table.ForeignKey(
                       name: "FK_NhanVien_TaiKhoan_IdTaiKhoan",
                       column: x => x.IdTaiKhoan,
                       principalTable: "TaiKhoan",
                       principalColumn: "IdTaiKhoan",
                       onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ThongBao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    TieuDe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayGui = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdNguoiGui = table.Column<int>(type: "int", nullable: false),
                    IdNguoiNhan = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongBao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ThuPhi",
                columns: table => new
                {
                    IdThuPhi = table.Column<int>(type: "int", nullable: false),
                    IdDanCu = table.Column<int>(type: "int", nullable: false),
                    ThoiGian = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhiQuanLy = table.Column<double>(type: "float", nullable: false),
                    PhiDien = table.Column<double>(type: "float", nullable: false),
                    PhiNuoc = table.Column<double>(type: "float", nullable: false),
                    PhiDichVu = table.Column<double>(type: "float", nullable: false),
                    PhiGuiXe = table.Column<double>(type: "float", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThuPhi", x => x.IdThuPhi);
                });

            migrationBuilder.CreateTable(
                name: "TienIch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    TenTienIch = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vitri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GioMoCua = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdNhanVien = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TienIch", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CanHo");

            migrationBuilder.DropTable(
                name: "DanCu");

            migrationBuilder.DropTable(
                name: "HopDong");

            migrationBuilder.DropTable(
                name: "NhanVien");

            migrationBuilder.DropTable(
                name: "SuCo");

            migrationBuilder.DropTable(
                name: "TaiKhoan");

            migrationBuilder.DropTable(
                name: "ThongBao");

            migrationBuilder.DropTable(
                name: "ThuPhi");

            migrationBuilder.DropTable(
                name: "TienIch");
            migrationBuilder.Sql(
                @"
                    DROP TRIGGER IF EXISTS update_canho_tinhtrang;
                "
            );
        }
    }
}
