import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ServicesService } from 'src/app/admin/admin-services/services.service';
import { hoadon } from 'src/app/Models/hoadon';

@Component({
  selector: 'app-xacnhandonhang',
  templateUrl: './xacnhandonhang.component.html',
  styleUrls: ['./xacnhandonhang.component.css']
})
export class XacnhandonhangComponent {
 
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
  constructor( public dialogRef: MatDialogRef<XacnhandonhangComponent>, @Inject(MAT_DIALOG_DATA) public data: hoadon) {
    if (data) {
      this.hoadon = data; 
    } else {
    console.error("Dữ liệu không hợp lệ:", data);
  }
  }


  onClose(): void {
    this.dialogRef.close();
  }
  onCancel(): void {
    this.dialogRef.close();
  }
  hienthi(){
    console.log("tehfs", this.hoadon.code);
  }
  
}
