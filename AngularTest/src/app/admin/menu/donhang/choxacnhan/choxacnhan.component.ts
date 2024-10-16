import { Component, OnInit } from '@angular/core';
import { ServicesService } from 'src/app/admin/admin-services/services.service';
import { hoadon } from 'src/app/Models/hoadon';

@Component({
  selector: 'app-choxacnhan',
  templateUrl: './choxacnhan.component.html',
  styleUrls: ['./choxacnhan.component.css']
})
export class ChoxacnhanComponent  implements OnInit{
  
  hoadon:hoadon[]=[];
  p:number=1;
constructor(private service: ServicesService){}
ngOnInit(): void {
  this.hienthi();
}
hienthi(){
  debugger;
  this.service.xacnhadonhang().subscribe(
    (data)=>{
    this.hoadon = data;
  })
}
xacnhanall(){
  this.service.xacnhanall().subscribe((reponse)=>{
   console.log("thanh congzzz");
   window.location.reload();
  })
}

}
