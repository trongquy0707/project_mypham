import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ServicesService } from 'src/app/admin/admin-services/services.service';
// import { hinhanh } from 'src/app/admin/Models/hinhanh';
import { hinhanh } from 'src/app/Models/hinhanh';
@Component({
  selector: 'app-hienthihinhanh',
  templateUrl: './hienthihinhanh.component.html',
  styleUrls: ['./hienthihinhanh.component.css']
})
export class HienthihinhanhComponent {
  private baseUrl = 'https://localhost:44353';
  ListImage: hinhanh[];
  constructor(public dialogRef: MatDialogRef<HienthihinhanhComponent>,
     private serveice: ServicesService, 
     @Inject(MAT_DIALOG_DATA) public data: hinhanh[] ) 
     {
      this.ListImage = data;
     }
  onClose(): void {
    this.dialogRef.close();
  }
 
  thu(){
    console.log("hien thi");
  }
  xoaanh(maHinhAnh: number){
    debugger;
    this.serveice.xoaanh(maHinhAnh).subscribe({
      next: () => {
        console.log('Xóa thành công');
       
        this.ListImage = this.ListImage.filter(image => image.maHinhAnh !== maHinhAnh);
      },
      error: (err) => {
        console.error('Lỗi khi xóa hình ảnh:', err);
      }
    });
  }
  
}
