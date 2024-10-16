import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ClientservicesService } from 'src/app/client/client-services/clientservices.service';
import { loggin } from 'src/app/Models/loggin';
import { loginreponse } from 'src/app/Models/loginreponse';

@Component({
  selector: 'app-loggin',
  templateUrl: './loggin.component.html',
  styleUrls: ['./loggin.component.css']
})
export class LogginComponent implements OnInit {
loggin:loggin={
  email: '',
  matKhau: '',
};
testmoi:string='';
constructor(private service: ClientservicesService, private route: Router){}
ngOnInit(): void {
  
}

dangnhap(){
 
  const formdata = new FormData();
  formdata.append('email',this.loggin.email.toString());
  formdata.append('matKhau', this.loggin.matKhau.toString());
  formdata.forEach((value, key) => {
    console.log(key, value);
  });


  this.service.loggin(formdata).subscribe(
    (reponse: loginreponse )=>{
    
      if(reponse.success){
        const machuvu = reponse.taikhoan.maChucVu;
        localStorage.setItem('token', reponse.token);
        this.testmoi = reponse.token;
        
        if(machuvu == 1){
          this.route.navigate(["/admin"])
          
        }else{
          this.route.navigate(["/client"])
        }
      }else{
        alert("dang nhap that bai")
      }
    } 
  )
}
}
