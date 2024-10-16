import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ClientservicesService } from 'src/app/client/client-services/clientservices.service';
import { register } from 'src/app/Models/register';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent {
  register: register = {
    hoTen: '',
    email: '',
    sDT: '',
    matKhau: '',
    reurnMatKhau: '',
  };
  constructor(private service: ClientservicesService, private router: Router) {}
  dangky() {
    const formData = new FormData();
    formData.append('hoTen', this.register.hoTen.toString());
    formData.append('email', this.register.email.toString());
    formData.append('sDT', this.register.sDT.toString());
    formData.append('matKhau', this.register.matKhau.toString());
    formData.append('reurnMatKhau', this.register.reurnMatKhau.toString());
    this.service.register(formData).subscribe({
      next: (data) => {
        console.log('Thành công:', data);
        this.router.navigate(['client/loggin']);
      },
      error: (er) => {
        console.log(er);
      },
    });
    
  }
}
