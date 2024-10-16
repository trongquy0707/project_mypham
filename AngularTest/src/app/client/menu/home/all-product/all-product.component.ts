import { Component, OnInit } from '@angular/core';
import { ClientservicesService } from 'src/app/client/client-services/clientservices.service';
import { SanPhamChiTiet } from 'src/app/Models/SanPhamChiTiet';

@Component({
  selector: 'app-all-product',
  templateUrl: './all-product.component.html',
  styleUrls: ['./all-product.component.css']
})
export class AllProductComponent implements OnInit{
sanphamchitiet:SanPhamChiTiet[]=[];
constructor(private service: ClientservicesService){}
search:string='';
private baseUrl ='https:localhost:44353';

ngOnInit(): void {
  this.hienthisanpham();
  console.log("dat la", this.sanphamchitiet);
}
hienthisanpham(){
  this.service.getAllProduct(this.search).subscribe((data)=>{
    debugger;
    this.sanphamchitiet=data.map(sanpham=>{
      return{
        ...sanpham,
        hinhAnhChinh:`${this.baseUrl}${sanpham.hinhAnhChinh}`
      }
    })
  })
}
}
