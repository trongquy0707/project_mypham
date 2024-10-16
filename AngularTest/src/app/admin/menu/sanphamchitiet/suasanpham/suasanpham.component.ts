import { Component } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { ServicesService } from "src/app/admin/admin-services/services.service";
// import { DanhMuc } from "src/app/admin/Models/DanhMuc";
// import { SanPhamChiTiet } from "src/app/admin/Models/SanPhamChiTiet";
import { DanhMuc } from 'src/app/Models/DanhMuc'; 
import { SanPhamChiTiet } from 'src/app/Models/SanPhamChiTiet'; 

@Component({
  selector: 'app-suasanpham',
  templateUrl: './suasanpham.component.html',
  styleUrls: ['./suasanpham.component.css']
})
export class SuasanphamComponent {
  SanPhamChiTiet: SanPhamChiTiet = {
    maSP: 0,
    tenSanPham: '',
    hinhAnhChinh: '',
    giaGoc: 0,
    giaSale: 0,
    moTaChiTiet: '',
    phanTramSale: 0,
    isSale: false,
    isHome: false,
    trangThai: 0,
    maDanhMuc: 0,
    file:[],
    rdfaut:[],
  };
  DanhMuc: DanhMuc[] = [];
  maSP: any;
 
  constructor(private service: ServicesService, private route: Router, private active: ActivatedRoute) { }
  ngOnInit(): void {
    this.maSP = this.active.snapshot.paramMap.get('maSP');
    debugger;
    this.service.getbyidsanpham(this.maSP).subscribe((data) => {
      this.SanPhamChiTiet = data;
    });
    this.getdanhmuc();
  };
  suasanpham() {
 
    const formdata = new FormData();
    formdata.append('tenSanPham', this.SanPhamChiTiet.tenSanPham.toString());
    formdata.append('giaGoc', this.SanPhamChiTiet.giaGoc.toString());
    formdata.append('giaSale', this.SanPhamChiTiet.giaSale.toString());
    formdata.append('isHome', this.SanPhamChiTiet.isHome.toString());
    formdata.append('isSale', this.SanPhamChiTiet.isSale.toString());
    formdata.append('moTaChiTiet', this.SanPhamChiTiet.moTaChiTiet.toString());
    formdata.append('maDanhMuc', this.SanPhamChiTiet.maDanhMuc.toString());
    formdata.append('trangThai', this.SanPhamChiTiet.trangThai.toString());
    formdata.append('phanTramSale', this.SanPhamChiTiet.phanTramSale.toString());
 this.service.suasanpham(this.maSP, formdata).subscribe({
   next: (data) => {
     console.log('Thành công:', data);
     this.route.navigate(['admin/HienthiSanPham']);
   },
   error: (er) => {
     console.log(er);
   },
 });
}
  getdanhmuc():void{
    this.service.getCategory().subscribe((data)=>{
      this.DanhMuc=data;
    });
  }
}
