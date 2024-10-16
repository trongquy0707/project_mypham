import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ServicesService } from 'src/app/admin/admin-services/services.service';
import { hoadonchitiet } from 'src/app/Models/hoadonchitiet';
import { SanPhamChiTiet } from 'src/app/Models/SanPhamChiTiet';

@Component({
  selector: 'app-list-order',
  templateUrl: './list-order.component.html',
  styleUrls: ['./list-order.component.css']
})
export class ListOrderComponent implements OnInit {
  hoadonchitiet:hoadonchitiet[]=[];
  sanphamchitiet:SanPhamChiTiet[]=[];
  maHD:any;
constructor(private service: ServicesService, private active: ActivatedRoute){}
ngOnInit(): void {
  this.maHD= this.active.snapshot.paramMap.get('maHD');
  this.hienthilistOrder();
}
hienthilistOrder(){
  this.service.listOrder(this.maHD).subscribe((data)=>{
    this.hoadonchitiet=data;
  })
}
hienthi() {
  this.service.getsanphamchitiet().subscribe((data) => {
    this.sanphamchitiet=data;
  });
}
}
