import { Component, OnInit } from '@angular/core';
import { ClientservicesService } from 'src/app/client/client-services/clientservices.service';
import { SanPhamChiTiet } from 'src/app/Models/SanPhamChiTiet';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent  implements OnInit{
  sanphamchitiet: SanPhamChiTiet[]=[];
  getfive:SanPhamChiTiet[]=[];
  // limte: number =  1;
  private baseUrl='https://localhost:44353';
constructor(private service: ClientservicesService){}
search: string = '';
ngOnInit(): void {
  this.getsanphamchung();
}
getsanphamchung(){
  this.service.getProductHome().subscribe(data=>{
    this.sanphamchitiet=data.map(sanpham=>{
      return{
        ...sanpham,
        hinhAnhChinh:`${this.baseUrl}${sanpham.hinhAnhChinh}`,
      }
    }).slice(0,5);
    console.log("da la test",this.sanphamchitiet);
  })
 
}
}
