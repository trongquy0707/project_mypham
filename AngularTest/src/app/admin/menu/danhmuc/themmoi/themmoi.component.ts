import { ChangeDetectorRef, Component } from '@angular/core';
import { Router } from '@angular/router';
import { ServicesService } from 'src/app/admin/admin-services/services.service';
// import { DanhMuc } from 'src/app/admin/Models/DanhMuc';
import { DanhMuc } from 'src/app/Models/DanhMuc'; 
declare var CKFinder: any;
@Component({
  selector: 'app-themmoi',
  templateUrl: './themmoi.component.html',
  styleUrls: ['./themmoi.component.css']
})
export class ThemmoiComponent {
  list:DanhMuc={
    maDanhMuc: 0,
      anhDanhMuc:'',
      tenDangMuc: '',
      file:[],
  };
 imagePreview:string[]=[];
  currentId: number = 0;
  files:File[]=[];
  constructor(private services: ServicesService, private router :Router, private cd: ChangeDetectorRef ){}
  themmoi(){
    const formdata = new FormData();
    formdata.append('tenDangMuc', this.list.tenDangMuc.toString());
    this.files.forEach(anh=>{
      formdata.append('anhdanhmuc', anh,anh.name);
    })
    this.services.themmoi(formdata).subscribe({
      next: (data) => {
        console.log('Thành công:', data);
        this.router.navigate(["admin/danhmuc"]);
      },
      error: (er) => {
        console.error('Lỗi:', er);
      }
    })
  }
  onFileChange(event: any) {
    this.files = Array.from(event.target.files);
    this.imagePreview = [];
    this.files.forEach(file => {
      const reader = new FileReader();
      reader.onload = (e: any) => {
        this.imagePreview.push(e.target.result);
        this.cd.detectChanges();
      };
      reader.readAsDataURL(file);
    });
  }
  fileToURL(file: File): string {
    return URL.createObjectURL(file);
  }

  
 


}