import { Component, OnInit } from '@angular/core';
import { ClientservicesService } from 'src/app/client/client-services/clientservices.service';
import { SanPhamChiTiet } from 'src/app/Models/SanPhamChiTiet';

@Component({
  selector: 'app-flashsale',
  templateUrl: './flashsale.component.html',
  styleUrls: ['./flashsale.component.css']
})
export class FlashsaleComponent implements OnInit {
  sanphamchitiet:SanPhamChiTiet[]=[];
  private baseUrl = 'https://localhost:44353';
  constructor(private service: ClientservicesService ){}
  futureDate: number = new Date("2024-04-12T00:00:00").getTime();
  days: number = 0;
  hours: number = 0;
  minutes: number = 0;
  seconds: number = 0;

 ngOnInit(): void {
  setInterval(() => {
    // Lấy thời gian hiện tại
    const now = new Date().getTime();
    
    // Tính toán khoảng cách từ hiện tại đến ngày trong tương lai
    const distance = this.futureDate - now;

    // Nếu khoảng cách âm, đếm ngược đã kết thúc
    if (distance < 0) {
      this.days = 0;
      this.hours = 0;
      this.minutes = 0;
      this.seconds = 0;
    } else {
      this.days = Math.floor(distance / (1000 * 60 * 60 * 24));
      this.hours = Math.floor((distance / (1000 * 60 * 60)) % 24);
      this.minutes = Math.floor((distance / (1000 * 60)) % 60);
      this.seconds = Math.floor((distance / 1000) % 60);
    }
  }, 1000);
  this.getproduct();
}

getproduct(){
  this.service.getProductSale().subscribe((data)=>{
    this.sanphamchitiet = data.map(sanpham=>{
      return {
        ...sanpham,
        hinhAnhChinh:`${this.baseUrl}${sanpham.hinhAnhChinh}`
      }
    })
   
  })
}

  

}
