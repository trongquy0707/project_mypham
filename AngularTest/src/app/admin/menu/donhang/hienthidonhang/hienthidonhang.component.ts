import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ServicesService } from 'src/app/admin/admin-services/services.service';
import { hoadon } from 'src/app/Models/hoadon';
import { XacnhandonhangComponent } from '../xacnhandonhang/xacnhandonhang.component';

@Component({
  selector: 'app-hienthidonhang',
  templateUrl: './hienthidonhang.component.html',
  styleUrls: ['./hienthidonhang.component.css']
})
export class HienthidonhangComponent implements OnInit {
 hoadon: hoadon[]=[];
p:number=1;
constructor(private service: ServicesService, private dialog: MatDialog){}
  ngOnInit(): void {
    this.loadtrang();
  }
  loadtrang() {
    this.service.hienthiHoaDon().subscribe((data) => {
      this.hoadon = data;
    });
  }
tesr(){
  console.log(this.hoadon)
}
openDialog(maHD:number): void {
  debugger;
 this.service.detailOrder(maHD).subscribe(item=>{
  const dialogref = this.dialog.open(XacnhandonhangComponent,{
    width: '400px',
    data : item,
  });
 
  dialogref.afterClosed().subscribe(result =>{
    if(result){
      window.location.reload();
    }
  })
 })
}
}


