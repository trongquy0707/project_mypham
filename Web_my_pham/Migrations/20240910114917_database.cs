using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_my_pham.Migrations
{
    public partial class database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CHUC_VU",
                columns: table => new
                {
                    MaChucVu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenChucVu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CHUC_VU", x => x.MaChucVu);
                });

            migrationBuilder.CreateTable(
                name: "DANH_MUC_SAN_PHAM",
                columns: table => new
                {
                    MaDanhMuc = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnhDanhMuc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenDangMuc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DANH_MUC_SAN_PHAM", x => x.MaDanhMuc);
                });

            migrationBuilder.CreateTable(
                name: "HOA_DON",
                columns: table => new
                {
                    MaHD = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayMua = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TongTien = table.Column<float>(type: "real", nullable: true),
                    TenKhachHang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThanhPho = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    Quan_Huyen = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    Xa_Phuong = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    Ghi_Chu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Thanh_Toan = table.Column<int>(type: "int", nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: true),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HOA_DON", x => x.MaHD);
                });

            migrationBuilder.CreateTable(
                name: "TAI_KHOAN",
                columns: table => new
                {
                    MaUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDangNhap = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MatKhau = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaChucVu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TAI_KHOAN", x => x.MaUser);
                    table.ForeignKey(
                        name: "FK_TAI_KHOAN_CHUC_VU_MaChucVu",
                        column: x => x.MaChucVu,
                        principalTable: "CHUC_VU",
                        principalColumn: "MaChucVu",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SAN_PHAM_CHI_TIET",
                columns: table => new
                {
                    MaSP = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenSanPham = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HinhAnhChinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GiaGoc = table.Column<float>(type: "real", nullable: true),
                    GiaSale = table.Column<float>(type: "real", nullable: true),
                    MoTaChiTiet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhanTramSale = table.Column<float>(type: "real", nullable: true),
                    isSale = table.Column<bool>(type: "bit", nullable: false),
                    isHome = table.Column<bool>(type: "bit", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: true),
                    MaDanhMuc = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SAN_PHAM_CHI_TIET", x => x.MaSP);
                    table.ForeignKey(
                        name: "FK_SAN_PHAM_CHI_TIET_DANH_MUC_SAN_PHAM_MaDanhMuc",
                        column: x => x.MaDanhMuc,
                        principalTable: "DANH_MUC_SAN_PHAM",
                        principalColumn: "MaDanhMuc",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HINH_ANH",
                columns: table => new
                {
                    MaHinhAnh = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnhChinh = table.Column<bool>(type: "bit", nullable: true),
                    MaSanPham = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HINH_ANH", x => x.MaHinhAnh);
                    table.ForeignKey(
                        name: "FK_HINH_ANH_SAN_PHAM_CHI_TIET_MaSanPham",
                        column: x => x.MaSanPham,
                        principalTable: "SAN_PHAM_CHI_TIET",
                        principalColumn: "MaSP",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HOA_DON_CHI_TIET",
                columns: table => new
                {
                    MaHDCT = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoLuongMua = table.Column<int>(type: "int", nullable: true),
                    GiaBan = table.Column<float>(type: "real", nullable: true),
                    MaHD = table.Column<int>(type: "int", nullable: true),
                    MaSP = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HOA_DON_CHI_TIET", x => x.MaHDCT);
                    table.ForeignKey(
                        name: "FK_HOA_DON_CHI_TIET_HOA_DON_MaHD",
                        column: x => x.MaHD,
                        principalTable: "HOA_DON",
                        principalColumn: "MaHD",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HOA_DON_CHI_TIET_SAN_PHAM_CHI_TIET_MaSP",
                        column: x => x.MaSP,
                        principalTable: "SAN_PHAM_CHI_TIET",
                        principalColumn: "MaSP",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HINH_ANH_MaSanPham",
                table: "HINH_ANH",
                column: "MaSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_HOA_DON_CHI_TIET_MaHD",
                table: "HOA_DON_CHI_TIET",
                column: "MaHD");

            migrationBuilder.CreateIndex(
                name: "IX_HOA_DON_CHI_TIET_MaSP",
                table: "HOA_DON_CHI_TIET",
                column: "MaSP");

            migrationBuilder.CreateIndex(
                name: "IX_SAN_PHAM_CHI_TIET_MaDanhMuc",
                table: "SAN_PHAM_CHI_TIET",
                column: "MaDanhMuc");

            migrationBuilder.CreateIndex(
                name: "IX_TAI_KHOAN_MaChucVu",
                table: "TAI_KHOAN",
                column: "MaChucVu");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HINH_ANH");

            migrationBuilder.DropTable(
                name: "HOA_DON_CHI_TIET");

            migrationBuilder.DropTable(
                name: "TAI_KHOAN");

            migrationBuilder.DropTable(
                name: "HOA_DON");

            migrationBuilder.DropTable(
                name: "SAN_PHAM_CHI_TIET");

            migrationBuilder.DropTable(
                name: "CHUC_VU");

            migrationBuilder.DropTable(
                name: "DANH_MUC_SAN_PHAM");
        }
    }
}
