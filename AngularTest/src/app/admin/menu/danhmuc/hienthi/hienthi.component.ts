import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ServicesService } from 'src/app/admin/admin-services/services.service';
// import { DanhMuc } from 'src/app/admin/Models/DanhMuc';
import { ChangeDetectorRef } from '@angular/core';
import { DanhMuc } from 'src/app/Models/DanhMuc'; 
@Component({
  selector: 'app-hienthi',
  templateUrl: './hienthi.component.html',
  styleUrls: ['./hienthi.component.css']
})
export class HienthiComponent implements OnInit {
DanhMuc: DanhMuc[]=[];
constructor(private services : ServicesService, private router: Router, private cdr: ChangeDetectorRef ){}
  ngOnInit(): void {
  this.loadtrang();
  }
  private baseUrl = 'https://localhost:44353';
  loadtrang():void{
    this.services.getCategory().subscribe((data)=>{
      this.DanhMuc=(data).map(danhmuc=>
      {
        return{
          ...danhmuc,
          anhDanhMuc:`${this.baseUrl}${danhmuc.anhDanhMuc}`
        }
      }
      )
      this.cdr.detectChanges();
    });
  }
  reload = false;
  deleteCategory(maDanhMuc: number): void{
   const  confirmed = window.confirm('Bạn có chắc chắn muốn xóa không?');
   if (confirmed) {
    this.services.xoadanhmuc(maDanhMuc).subscribe({
      complete: () => {
        console.log('Xóa thành công (không có phản hồi)');
        window.location.reload();  // Làm mới trang sau khi hoàn tất
      },
    });
   }
   
  }

}
