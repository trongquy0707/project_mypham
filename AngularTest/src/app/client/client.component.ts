import { Component, OnInit } from '@angular/core';
import { ClientservicesService } from './client-services/clientservices.service';

@Component({
  selector: 'app-client',
  templateUrl: './client.component.html',
  styleUrls: ['./client.component.css']
})
export class ClientComponent implements OnInit {
  cartCount: any;
constructor(private service: ClientservicesService){}
ngOnInit(): void {
  this.getcount()
}
getcount(){
  this.service.getcount().subscribe((response : any)=>{
    this.cartCount=response;
  })
}
}
