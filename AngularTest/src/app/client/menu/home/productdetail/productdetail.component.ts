import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ClientservicesService } from 'src/app/client/client-services/clientservices.service';
import { addtocart } from 'src/app/Models/addtocart';
import { hinhanh } from 'src/app/Models/hinhanh';
import { SanPhamChiTiet } from 'src/app/Models/SanPhamChiTiet';
import { ShoppingCartItem } from 'src/app/Models/ShoppingCartItem';

@Component({
  selector: 'app-productdetail',
  templateUrl: './productdetail.component.html',
  styleUrls: ['./productdetail.component.css']
})
export class ProductdetailComponent {
  sanphamchitiet:SanPhamChiTiet[]=[];
  hinhanh:hinhanh[]=[];
 
  quantity: number = 1;
  maSP:any;
  hinhAnhChinh!: string;  
constructor(private service: ClientservicesService, private active: ActivatedRoute, private route: Router){}
private baseUrl = 'https://localhost:44353';
addToCart(id:number, quantity:number){
   
  const formData = new FormData();
  formData.append('id', id.toString());
  formData.append('quantity', quantity.toString());
  console.log("ma sp: ", id);
  console.log("ma sl: ",quantity);
debugger;
  this.service.addToCart(formData).subscribe(
    (response) => {
      console.log('Sản phẩm đã được thêm vào giỏ hàng:', response);
    },
    (error) => {
      console.error('Lỗi khi thêm vào giỏ hàng:', error);
    }
)
}
ngOnInit(): void{
  this.maSP = this.active.snapshot.paramMap.get('maSP');
  this.getproductdetail(this.maSP);
  this.getanhsanpham();
  
}

getproductdetail(maSP: number): void {
  this.service.getproductdetail(maSP).subscribe((sanpham) => {
    this.hinhAnhChinh = `${this.baseUrl}${sanpham.hinhAnhChinh}`;
    this.sanphamchitiet = [{
      ...sanpham,
      hinhAnhChinh: `${this.baseUrl}${sanpham.hinhAnhChinh}`
    }];
  }, (error) => {
    console.error('Error fetching product details:', error);
  });
}
getanhsanpham():void{
  this.service.getImageProduct(this.maSP).subscribe((data)=>{
    this.hinhanh=data.map(hinhanh=>{
      return{
         ...hinhanh,
        hinhAnh:`${this.baseUrl}${hinhanh.hinhAnh}`
      }
    })
  })
}

tangsoluong() {
  this.quantity += 1;
}

giamsoluong() {
  if (this.quantity > 1) {
    this.quantity -= 1;
  }
}
clickImage(imagePath:string):void { 
this.hinhAnhChinh=imagePath;
console.log("hinh anh chinh: ", this.hinhAnhChinh)
}


}
