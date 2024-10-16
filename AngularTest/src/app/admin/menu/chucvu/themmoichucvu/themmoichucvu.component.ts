import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ServicesService } from 'src/app/admin/admin-services/services.service';
import { ChucVu } from 'src/app/Models/ChucVu';
// import { ChucVu } from 'src/app/admin/Models/ChucVu';

@Component({
  selector: 'app-themmoichucvu',
  templateUrl: './themmoichucvu.component.html',
  styleUrls: ['./themmoichucvu.component.css']
})
export class ThemmoichucvuComponent {
list:ChucVu={
  tenChucVu:'',
  maChucVu:0,
};
constructor(private service: ServicesService, private route: Router){}
themoichucvu(){
  this.service.themchuvu(this.list).subscribe({
    next:(data)=>{
      this.route.navigate(["/admin/hienthichucvu"])
    }
  })
}
}
