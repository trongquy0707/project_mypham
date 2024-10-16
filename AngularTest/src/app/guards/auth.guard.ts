import { CanActivateFn, Router } from '@angular/router';
import { AppservicesService } from '../Appservice/appservices.service';
import { ɵɵinject } from '@angular/core';

export const authGuard: CanActivateFn = (route, state) => {
  
  const authService =  ɵɵinject(AppservicesService);
  const router = ɵɵinject(Router);
  
  if (authService.isLoggedIn()) {
 
    return true; 
  } else {
    router.navigate(['/client/loggin']); 
    return false;
  }
};
