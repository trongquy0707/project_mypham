import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AppservicesService } from 'src/app/Appservice/appservices.service';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent {
  constructor(private services: AppservicesService, private route: Router){}
logout(){
  this.services.logout();
  this.route.navigate(['/client/loggin'])
}
}
