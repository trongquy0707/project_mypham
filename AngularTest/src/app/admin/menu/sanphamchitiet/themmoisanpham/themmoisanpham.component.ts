import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import ClassicEditor from '@ckeditor/ckeditor5-build-classic';
import { ServicesService } from 'src/app/admin/admin-services/services.service';
// import { DanhMuc } from 'src/app/admin/Models/DanhMuc';
// import { SanPhamChiTiet } from 'src/app/admin/Models/SanPhamChiTiet';
import { DanhMuc } from 'src/app/Models/DanhMuc'; 
import { SanPhamChiTiet } from 'src/app/Models/SanPhamChiTiet'; 
@Component({
  selector: 'app-themmoisanpham',
  templateUrl:'./themmoisanpham.component.html',
  styleUrls: ['./themmoisanpham.component.css'],
})
export class ThemmoisanphamComponent implements OnInit {
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
  files: File[] = [];
  selectedMainImages: number[] = []; 
  DanhMuc: DanhMuc[] = [];
  imagePreviews: string[] = [];
  constructor(private service: ServicesService, private route: Router, private cd: ChangeDetectorRef) {}
  ngOnInit(): void {

    this.getdanhmuc();
  }
  

  themsanpham() {
 
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
       this.files.forEach(file => {
        formdata.append('Images', file, file.name);
      });
      this.selectedMainImages.forEach(index => {
        formdata.append('RDefault', index.toString());
      });

    this.service.themsanpham(formdata).subscribe({
      next: (data) => {
        console.log('Thành công:', data);
        this.route.navigate(['admin/HienthiSanPham']);
      },
      error: (er) => {
        console.log(er);
      },
    });
  }

  getdanhmuc(): void {
    this.service.getCategory().subscribe((data) => {
      this.DanhMuc = data;
    });
  }

  public Editor = ClassicEditor;
  public editorData = '<p>Hello, world!</p>';

  onFileChange(event: any) {
    this.files = Array.from(event.target.files);
    this.imagePreviews = [];
    this.files.forEach(file => {
      const reader = new FileReader();
      reader.onload = (e: any) => {
        this.imagePreviews.push(e.target.result);
        this.cd.detectChanges();
      };
      reader.readAsDataURL(file);
    });
  }

  onMainImageChange(event: any, index: number) {
    if (event.target.checked) {
      this.selectedMainImages.push(index + 1); // Push the 1-based index to the list
    } else {
      const idx = this.selectedMainImages.indexOf(index + 1);
      if (idx !== -1) {
        this.selectedMainImages.splice(idx, 1); // Remove the index from the list if unchecked
      }
    }
  }
  
}
