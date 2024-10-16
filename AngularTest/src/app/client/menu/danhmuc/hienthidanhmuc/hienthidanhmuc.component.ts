import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { ClientservicesService } from 'src/app/client/client-services/clientservices.service';
import { DanhMuc } from 'src/app/Models/DanhMuc';
import { SanPhamChiTiet } from 'src/app/Models/SanPhamChiTiet';

@Component({
  selector: 'app-hienthidanhmuc',
  templateUrl: './hienthidanhmuc.component.html',
  styleUrls: ['./hienthidanhmuc.component.css']
})
export class HienthidanhmucComponent implements OnInit{
constructor(private service: ClientservicesService, private cdr: ChangeDetectorRef){}
danhmuc:DanhMuc[]=[];
SanPhamChiTiet:SanPhamChiTiet[]=[];
ngOnInit(): void {
  this.getcategory();
}
private baseUrl = 'https://localhost:44353';
getcategory():void{
   this.service.getallCategory().subscribe((data)=>{
    this.danhmuc=(data).map(danhmuc=>
      {
        return{
          ...danhmuc,
          anhDanhMuc:`${this.baseUrl}${danhmuc.anhDanhMuc}`
        }
      }
      )
      this.cdr.detectChanges();
  })
}

GetProductcsCategory(maDanhMuc: number):void{
  this.service.GetProductCategory(maDanhMuc).subscribe((data)=>{
    this.SanPhamChiTiet = data.map(sanpham =>{
      return {
        ...sanpham,
        hinhAnhChinh:`${this.baseUrl}${sanpham.hinhAnhChinh}`
      };
    })
  })
}
}
