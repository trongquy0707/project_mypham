import { HttpClient } from '@angular/common/http';
import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ClientservicesService } from 'src/app/client/client-services/clientservices.service';
import { ShoppingCartItem } from 'src/app/Models/ShoppingCartItem';

@Component({
  selector: 'app-showcart',
  templateUrl: './showcart.component.html',
  styleUrls: ['./showcart.component.css']
})
export class ShowcartComponent implements OnInit {
  ItemCats:ShoppingCartItem[]=[];
  quantityy:number=1;
  tongTien:number=0;
constructor(
  private service:ClientservicesService , 
  private crd: ChangeDetectorRef,
   private active: ActivatedRoute, 
   private http: HttpClient,
   private router: Router,
  ){}
private baseUrl = 'https://localhost:44353';
ngOnInit(): void {
  
this.getcart();

}
getcart():void{
  this.service.getcart().subscribe((data)=>{   
    this.ItemCats=data.map(items=>{
      this.tongTien += items.tongGia;
      return{
         ...items,
       anhSanPham: `${this.baseUrl}${items.anhSanPham}`,
       
      }
    });
    
    console.log('Dữ liệu giỏ hàng:', this.quantityy); 
  })
  
}

xoaCartItem(id:number){
 debugger;
  this.service.xoaItemCart(id).subscribe({
    next:()=>{
      console.log('Xóa thành công (không có phản hồi)');
      this.ItemCats = this.ItemCats.filter(item => item.idSanPham !== id);
      console.log('Danh sách giỏ hàng sau khi xóa:', this.ItemCats);
    },
    error: (err) => {
      console.error('Có lỗi xảy ra khi xóa sản phẩm:', err);
    }
    }
  )
}


updateQuantiy(id:number, quantity : number){
  const formData = new FormData();
  formData.append('id', id.toString());
  formData.append('quantity', quantity.toString());
  this.service.updateQuantity(formData).subscribe(
    {
      next:()=>{
        console.log('Xóa thành công (không có phản hồi)');
      
        console.log('Danh sách giỏ hàng sau khi xóa:', this.ItemCats);
      },
      error: (err) => {
        console.error('Có lỗi xảy ra khi xóa sản phẩm:', err);
      }
      }
  )
}
tangsoluong(item: ShoppingCartItem){
  item.soLuong ++;
  this.updateQuantiy(item.idSanPham,item.soLuong)
  item.tongGia += item.giaSanPham;
  this.tinhTongTien()
}
giamsoluong(item:ShoppingCartItem){
 if(item.soLuong > 1){
  item.soLuong --;
  this.updateQuantiy(item.idSanPham,item.soLuong)
  item.tongGia -= item.giaSanPham;
  this.tinhTongTien()
 }
 
 }

 tinhTongTien() {
  this.tongTien = 0; 
  this.ItemCats.forEach(item => {
    this.tongTien += item.soLuong * item.giaSanPham; 
  });
 
}

processPayment() {
  this.http.get('https://localhost:44353/api/ShoppingCart/returnVnpay?params').subscribe((response: any) => {
    if (response.isSuccess) {
      // Chuyển hướng đến trang thông báo
      this.router.navigate(['/thong-bao'], { state: { message: response.message, tenKhachHang: response.tenKhachHang, amount: response.amount } });
    }
  });
}
}
