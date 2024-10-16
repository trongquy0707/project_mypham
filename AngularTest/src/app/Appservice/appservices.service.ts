import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AppservicesService {

  constructor() { }
  isLoggedIn(): boolean {
   
    const token = localStorage.getItem('token');
    console.log("test", token);  
    return token !== null;
  }

  
  logout() {
    localStorage.removeItem('token');
  }

}
