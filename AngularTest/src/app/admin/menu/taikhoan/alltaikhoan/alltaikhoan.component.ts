import { Component, OnInit } from '@angular/core';
import { ServicesService } from 'src/app/admin/admin-services/services.service';
import { taikhoan } from 'src/app/Models/taikhoan';

@Component({
  selector: 'app-alltaikhoan',
  templateUrl: './alltaikhoan.component.html',
  styleUrls: ['./alltaikhoan.component.css']
})
export class AlltaikhoanComponent implements OnInit {
taikhoan:taikhoan[]=[];
constructor(private service:ServicesService){}
ngOnInit(): void {
  this.hienthi();
}
hienthi(){
  this.service.getalltaikhoan().subscribe((data)=>{
    this.taikhoan=data;
  })
}
capquyenadmin(id:number,machucvu:number){
  const formdata = new FormData();
  formdata.append('id',id.toString());
  formdata.append('machucvu',machucvu.toString())
  this.service.capquyen(formdata).subscribe((reponse)=>{
    console.log("thanh cong");
    window.location.reload();
  })
}
}
