import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ClientservicesService } from 'src/app/client/client-services/clientservices.service';
import { order } from 'src/app/Models/order';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent implements OnInit {
orders: order={
  tenKhachHang  : '' , 
  soDienThoai  : '' ,
  email  : '',
  thanhPho  : '' ,
  quan_Huyen  : '' ,
  xa_Phuong  : '' ,
  ghi_Chu  : '' ,
 thanh_Toan  : 0,
thanh_Toan_VnPay  : 0,
};
cities: any[] = [];
  districts: any[] = [];
  wards: any[] = [];
  selectCity: string = '';
  selectDistricts: string = '';
  selectedWard: string='';
constructor(private service:ClientservicesService, private route: Router, private http: HttpClient){}
ngOnInit(): void {
  this.getCities(); 
}
  checkout(){

    const formdata = new FormData();
    formdata.append('tenKhachHang', this.orders.tenKhachHang.toString())
    formdata.append('soDienThoai', this.orders.soDienThoai.toString())
    formdata.append('email', this.orders.email.toString())
    formdata.append('thanhPho', this.selectCity.toString())
    formdata.append('quan_Huyen', this.selectDistricts.toString())
    formdata.append('xa_Phuong', this.selectedWard.toString())
    formdata.append('ghi_Chu', this.orders.ghi_Chu.toString())
    formdata.append('thanh_Toan', this.orders.thanh_Toan.toString())
    formdata.append('thanh_Toan_VnPay', this.orders.thanh_Toan_VnPay.toString())
  debugger;
    this.service.checkout(formdata).subscribe({
      next: (response: any) => {
        const paymentLink = response;
        if (paymentLink) {
          window.location.href = paymentLink;
        } else {
          console.error("Không nhận được đường link thanh toán.");
        }
        if(response.thanh_Toan == 1){
          this.route.navigate(['/client/returnfail'])
        }
      },
      error: (error) => {
        console.error('Checkout thất bại:', error);
      },
    });
  }

getCities() {
  this.http.get('https://raw.githubusercontent.com/kenzouno1/DiaGioiHanhChinhVN/master/data.json')
    .subscribe((data: any) => {
      this.cities = data;
    });
}

onChangeCity() {
  this.districts = [];
  this.wards = []; 
  const city = this.cities.find(c => c.Name === this.selectCity); 
  if (city) {
    this.districts = city.Districts; 
  }
}

onChangeDistrict() {
  this.wards = []; 
  const city = this.cities.find(c => c.Name === this.selectCity); 
  if (city) {
    const district = city.Districts.find((d:any) => d.Name === this.selectDistricts); 
    if (district) {
      this.wards = district.Wards; 
    }
  }
}

}
