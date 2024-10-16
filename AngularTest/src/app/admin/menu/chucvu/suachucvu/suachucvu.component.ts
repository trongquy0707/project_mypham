import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ActivationEnd, Router } from '@angular/router';
import { ServicesService } from 'src/app/admin/admin-services/services.service';
import { ChucVu } from 'src/app/Models/ChucVu';
// import { ChucVu } from 'src/app/admin/Models/ChucVu';

@Component({
  selector: 'app-suachucvu',
  templateUrl: './suachucvu.component.html',
  styleUrls: ['./suachucvu.component.css']
})
export class SuachucvuComponent implements OnInit {
 list: ChucVu={
  maChucVu:0,
  tenChucVu : "",
}
maChucvu!:any;
constructor(private service: ServicesService, private router : Router, private actvie: ActivatedRoute ){}
ngOnInit(): void{
  this.maChucvu=this.actvie.snapshot.paramMap.get("maChucVu");
  this.service.getbychucvuid(this.maChucvu).subscribe((data)=>{
    this.list=data;
  });
  
}

suachucvus(){
  debugger;
  console.log(this.maChucvu);
  return this.service.suachucvu(this.maChucvu, this.list).subscribe((response)=>{
    alert(response);
    this.router.navigate(["/admin/hienthichucvu"])
  }) ;
}


}
