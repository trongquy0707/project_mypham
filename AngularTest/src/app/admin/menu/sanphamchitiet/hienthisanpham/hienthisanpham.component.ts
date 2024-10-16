import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ServicesService } from 'src/app/admin/admin-services/services.service';
// import { DanhMuc } from 'src/app/admin/Models/DanhMuc';
// import { SanPhamChiTiet } from 'src/app/admin/Models/SanPhamChiTiet';
import { DanhMuc } from 'src/app/Models/DanhMuc'; 
import { SanPhamChiTiet } from 'src/app/Models/SanPhamChiTiet'; 
import { MatDialog } from '@angular/material/dialog';
import { HienthihinhanhComponent } from '../../hinhanh/hienthihinhanh/hienthihinhanh.component';

@Component({
  selector: 'app-hienthisanpham',
  templateUrl: './hienthisanpham.component.html',
  styleUrls: ['./hienthisanpham.component.css'],
})
export class HienthisanphamComponent implements OnInit {
  SanPhamChiTiet: SanPhamChiTiet[] = [];
  DanhMuc: DanhMuc[] = [];
  maSP: any;
  maDanhMuc: any;
  p:number=1;

  constructor(
    private services: ServicesService,
    private route: Router,
    private active: ActivatedRoute,
    public dialog: MatDialog
  ) {}
  ngOnInit(): void {
    this.hienthi();
    this.maSP = this.active.snapshot.paramMap.get('maSP');
    this.services.getbyidsanpham(this.maSP).subscribe((data) => {});
    this.maDanhMuc = this.active.snapshot.paramMap.get('maDanhMuc');
    this.getdanhmuc();
  }
  private baseUrl = 'https://localhost:44353';
  hienthi() {
    this.services.getsanphamchitiet().subscribe((data) => {
      this.SanPhamChiTiet = data.map(sanPham => {
        return {
          ...sanPham,
          hinhAnhChinh: `${this.baseUrl}${sanPham.hinhAnhChinh}`
        };
      });
    });
  }
  ishome(maSP: number) {
    this.services.ishome(maSP).subscribe({
      next: () => {
        console.log('Cập nhật isHome thành công');
        // Tìm sản phẩm trong danh sách và cập nhật giá trị isHome
        const product = this.SanPhamChiTiet.find((sp) => sp.maSP === maSP);
        if (product) {
          product.isHome = !product.isHome; // Đảo ngược trạng thái isHome
        }
      },
    });
  }
  issale(maSP: number) {
    this.services.issale(maSP).subscribe({
      next: () => {
        console.log('Xóa thành công (không có phản hồi)');
        const product = this.SanPhamChiTiet.find((sp)=>sp.maSP == maSP);
        if(product){
          product.isSale=!product.isSale;
        } // Làm mới trang sau khi hoàn tất
      },
    });
  }
  

  getdanhmuc() {
    this.services.getCategory().subscribe((data) => {
      this.DanhMuc = data;
    });
  }

  getCategoryName(maDanhMuc: any): string {
    const category = this.DanhMuc.find(cat => cat.maDanhMuc === maDanhMuc);
    return category ? category.tenDangMuc : 'Unknown';
  }
  xoasanpham(maSP:number) {
    var confimed = window.confirm("bạn có chắc chắn muốn xóa sản phẩm");
    if(confimed){
      this.services.xoasanpham(maSP).subscribe({
        next: () => {
          console.log('Xóa thành công (không có phản hồi)');
          this.SanPhamChiTiet= this.SanPhamChiTiet.filter((sp)=>sp.maSP !== maSP);
         
        },
      });
    }
    
  }

 openDialog(maSP:number): void {
    this.services.hienthihinhanh(maSP).subscribe(sp=>{
       const dialogRef = this.dialog.open(HienthihinhanhComponent, {
      data:sp,
    });
    console.log(sp);

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        window.location.reload();
      }
    });
    })
  
  }
  


  
}
