import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ServicesService } from 'src/app/admin/admin-services/services.service';
// import { DanhMuc } from 'src/app/admin/Models/DanhMuc';
import { DanhMuc } from 'src/app/Models/DanhMuc'; 
@Component({
  selector: 'app-suadanhmuc',
  templateUrl: './suadanhmuc.component.html',
  styleUrls: ['./suadanhmuc.component.css']
})
export class SuadanhmucComponent  {
  list:DanhMuc={
     maDanhMuc: 0,
      anhDanhMuc: '',
      tenDangMuc: '',
      file:[],
  };
MaDanhMuc!: any;
 
  constructor(private services : ServicesService, private active: ActivatedRoute, private router: Router){ };

  ngOnInit(): void { 
    this.MaDanhMuc=this.active.snapshot.paramMap.get('maDanhMuc');
    this.services.getbyid(this.MaDanhMuc).subscribe((data)=>{
      this.list =data;
    }
    );
  
  }

  // suadanhmuc(){
    
  //   this.services.suadanhmuc(this.MaDanhMuc).subscribe((response )=>{
  //     console.log("day la ", this.list )
  //     // alert(response);
  //     this.router.navigate(["/admin/danhmuc"])
  //   })
  // }
  suadanhmuc(){
    const formdata = new FormData();
    formdata.append('tenDangMuc', this.list.tenDangMuc.toString());
    // this.files.forEach(anh=>{
    //   formdata.append('anhdanhmuc', anh,anh.name);
    // })
    this.services.suadanhmuc(this.MaDanhMuc,formdata).subscribe({
      next: (data) => {
        console.log('Thành công:', data);
        this.router.navigate(["admin/danhmuc"]);
      },
      error: (er) => {
        console.error('Lỗi:', er);
      }
    })
  }

}

