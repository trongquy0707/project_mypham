import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ClientservicesService } from 'src/app/client/client-services/clientservices.service';
import { SanPhamChiTiet } from 'src/app/Models/SanPhamChiTiet';

@Component({
  selector: 'app-productcategory',
  templateUrl: './productcategory.component.html',
  styleUrls: ['./productcategory.component.css']
})
export class ProductcategoryComponent {
  SanPhamChiTiet: SanPhamChiTiet[]=[];
constructor(private service: ClientservicesService, private active: ActivatedRoute){}
private baseUrl = 'https://localhost:44353';
// GetProductcsCategory(maDanhMuc: number):void{
//   this.service.GetProductCategory(maDanhMuc).subscribe((data)=>{
//     this.SanPhamChiTiet = data.map(sanpham =>{
//       return {
//         ...sanpham,
//         hinhAnhChinh:`${this.baseUrl}${sanpham.hinhAnhChinh}`
//       };
//     })
//   })
// }
maDanhmuc:any;
ngOnInit(): void {
  this.maDanhmuc = this.active.snapshot.paramMap.get('maDanhMuc');
  
  this.service.GetProductCategory(this.maDanhmuc).subscribe((data) => {
    
    this.SanPhamChiTiet = data.map(sanpham =>{
      return{
        ...sanpham,
        hinhAnhChinh:`${this.baseUrl}${sanpham.hinhAnhChinh}`
      }
    })
  });
};

}
