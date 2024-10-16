﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Web_my_pham.Data;

namespace Web_my_pham.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20240910114917_database")]
    partial class database
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Web_my_pham.Data.CHUC_VU", b =>
                {
                    b.Property<int>("MaChucVu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("TenChucVu")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaChucVu");

                    b.ToTable("CHUC_VU");
                });

            modelBuilder.Entity("Web_my_pham.Data.DANH_MUC_SAN_PHAM", b =>
                {
                    b.Property<int>("MaDanhMuc")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("AnhDanhMuc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenDangMuc")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaDanhMuc");

                    b.ToTable("DANH_MUC_SAN_PHAM");
                });

            modelBuilder.Entity("Web_my_pham.Data.HINH_ANH", b =>
                {
                    b.Property<int>("MaHinhAnh")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool?>("AnhChinh")
                        .HasColumnType("bit");

                    b.Property<string>("HinhAnh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MaSanPham")
                        .HasColumnType("int");

                    b.HasKey("MaHinhAnh");

                    b.HasIndex("MaSanPham");

                    b.ToTable("HINH_ANH");
                });

            modelBuilder.Entity("Web_my_pham.Data.HOA_DON", b =>
                {
                    b.Property<int>("MaHD")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Ghi_Chu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgayMua")
                        .HasColumnType("datetime2");

                    b.Property<string>("Quan_Huyen")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("SoDienThoai")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SoLuong")
                        .HasColumnType("int");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<string>("TenKhachHang")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThanhPho")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<int?>("Thanh_Toan")
                        .HasColumnType("int");

                    b.Property<float?>("TongTien")
                        .HasColumnType("real");

                    b.Property<string>("Xa_Phuong")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("MaHD");

                    b.ToTable("HOA_DON");
                });

            modelBuilder.Entity("Web_my_pham.Data.HOA_DON_CHI_TIET", b =>
                {
                    b.Property<int>("MaHDCT")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<float?>("GiaBan")
                        .HasColumnType("real");

                    b.Property<int?>("MaHD")
                        .HasColumnType("int");

                    b.Property<int?>("MaSP")
                        .HasColumnType("int");

                    b.Property<int?>("SoLuongMua")
                        .HasColumnType("int");

                    b.HasKey("MaHDCT");

                    b.HasIndex("MaHD");

                    b.HasIndex("MaSP");

                    b.ToTable("HOA_DON_CHI_TIET");
                });

            modelBuilder.Entity("Web_my_pham.Data.SAN_PHAM_CHI_TIET", b =>
                {
                    b.Property<int>("MaSP")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<float?>("GiaGoc")
                        .HasColumnType("real");

                    b.Property<float?>("GiaSale")
                        .HasColumnType("real");

                    b.Property<string>("HinhAnhChinh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MaDanhMuc")
                        .HasColumnType("int");

                    b.Property<string>("MoTaChiTiet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("PhanTramSale")
                        .HasColumnType("real");

                    b.Property<string>("TenSanPham")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TrangThai")
                        .HasColumnType("int");

                    b.Property<bool>("isHome")
                        .HasColumnType("bit");

                    b.Property<bool>("isSale")
                        .HasColumnType("bit");

                    b.HasKey("MaSP");

                    b.HasIndex("MaDanhMuc");

                    b.ToTable("SAN_PHAM_CHI_TIET");
                });

            modelBuilder.Entity("Web_my_pham.Data.TAI_KHOAN", b =>
                {
                    b.Property<int>("MaUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaChucVu")
                        .HasColumnType("int");

                    b.Property<string>("MatKhau")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenDangNhap")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaUser");

                    b.HasIndex("MaChucVu");

                    b.ToTable("TAI_KHOAN");
                });

            modelBuilder.Entity("Web_my_pham.Data.HINH_ANH", b =>
                {
                    b.HasOne("Web_my_pham.Data.SAN_PHAM_CHI_TIET", "SAN_PHAM_CHI_TIET")
                        .WithMany("HINH_ANH")
                        .HasForeignKey("MaSanPham");

                    b.Navigation("SAN_PHAM_CHI_TIET");
                });

            modelBuilder.Entity("Web_my_pham.Data.HOA_DON_CHI_TIET", b =>
                {
                    b.HasOne("Web_my_pham.Data.HOA_DON", "HOA_DON")
                        .WithMany("HOA_DON_CHI_TIET")
                        .HasForeignKey("MaHD");

                    b.HasOne("Web_my_pham.Data.SAN_PHAM_CHI_TIET", "SAN_PHAM_CHI_TIET")
                        .WithMany("HOA_DON_CHI_TIET")
                        .HasForeignKey("MaSP");

                    b.Navigation("HOA_DON");

                    b.Navigation("SAN_PHAM_CHI_TIET");
                });

            modelBuilder.Entity("Web_my_pham.Data.SAN_PHAM_CHI_TIET", b =>
                {
                    b.HasOne("Web_my_pham.Data.DANH_MUC_SAN_PHAM", "DANH_MUC_SAN_PHAM")
                        .WithMany("SAN_PHAM_CHI_TIET")
                        .HasForeignKey("MaDanhMuc");

                    b.Navigation("DANH_MUC_SAN_PHAM");
                });

            modelBuilder.Entity("Web_my_pham.Data.TAI_KHOAN", b =>
                {
                    b.HasOne("Web_my_pham.Data.CHUC_VU", "CHUC_VU")
                        .WithMany("TAI_KHOAN")
                        .HasForeignKey("MaChucVu")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CHUC_VU");
                });

            modelBuilder.Entity("Web_my_pham.Data.CHUC_VU", b =>
                {
                    b.Navigation("TAI_KHOAN");
                });

            modelBuilder.Entity("Web_my_pham.Data.DANH_MUC_SAN_PHAM", b =>
                {
                    b.Navigation("SAN_PHAM_CHI_TIET");
                });

            modelBuilder.Entity("Web_my_pham.Data.HOA_DON", b =>
                {
                    b.Navigation("HOA_DON_CHI_TIET");
                });

            modelBuilder.Entity("Web_my_pham.Data.SAN_PHAM_CHI_TIET", b =>
                {
                    b.Navigation("HINH_ANH");

                    b.Navigation("HOA_DON_CHI_TIET");
                });
#pragma warning restore 612, 618
        }
    }
}