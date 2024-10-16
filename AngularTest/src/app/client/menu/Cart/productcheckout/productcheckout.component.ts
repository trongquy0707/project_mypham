import { Component } from '@angular/core';
import { ClientservicesService } from 'src/app/client/client-services/clientservices.service';
import { ShoppingCartItem } from 'src/app/Models/ShoppingCartItem';

@Component({
  selector: 'app-productcheckout',
  templateUrl: './productcheckout.component.html',
  styleUrls: ['./productcheckout.component.css']
})
export class ProductcheckoutComponent {
  ItemCats:ShoppingCartItem[]=[];
  quantityy:number=1;
  tongTienTamTinh:number=0;
  tonghoadon:number=0;
constructor(
  private service:ClientservicesService , 

  ){}
private baseUrl = 'https://localhost:44353';
ngOnInit(): void {
  
this.getcart();

}
getcart():void{
  this.service.getcart().subscribe((data)=>{   
    this.ItemCats=data.map(items=>{
      this.tongTienTamTinh += items.tongGia;
      this.tonghoadon = this.tongTienTamTinh+40000;
      return{
         ...items,
       anhSanPham: `${this.baseUrl}${items.anhSanPham}`,
       
      }
    });
    
    console.log('Dữ liệu giỏ hàng:', this.quantityy); 
  })
  
}


}
