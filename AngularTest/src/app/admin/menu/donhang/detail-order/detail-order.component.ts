import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ServicesService } from 'src/app/admin/admin-services/services.service';
import { hoadon } from 'src/app/Models/hoadon';

@Component({
  selector: 'app-detail-order',
  templateUrl: './detail-order.component.html',
  styleUrls: ['./detail-order.component.css']
})
export class DetailOrderComponent implements OnInit {
hoadon:hoadon={
  maHD: 0,
  ngayMua: '',
  tongTien: 0,
  tenKhachHang: '',
  code: '',
  thanhPho: '',
  quan_Huyen: '',
  xa_Phuong: '',
  ghi_Chu: '',
  email: '',
  thanh_Toan: 0,
  soLuong: 0,
  soDienThoai: '',
  status: 0
};
maHD:any;
constructor(private sevices : ServicesService, private active: ActivatedRoute){}
ngOnInit(): void {
  this.maHD = this.active.snapshot.paramMap.get('maHD');
  this.hienthidetailOrder(this.maHD);
};
isTrangThaiDisabled: boolean = false;
trangThai: number = 2;
hienthidetailOrder(maHD:any){
 this.sevices.detailOrder(maHD).subscribe((data)=>{
  this.hoadon=data;
  this.trangThai = this.hoadon.status;
  this.isTrangThaiDisabled = this.trangThai === 3;
 })
 
}
changetrangthai(event:any){
  
  const trangthai = event.target.value; 
 const formdata = new FormData;
 formdata.append('id',this.maHD.toString());
 formdata.append('trangthai',trangthai.toString());
  this.sevices.trangthaidonhang(formdata).subscribe(
    (data)=>{
    console.log("thanhcong");
    window.location.reload();
  }
)
}

}
