import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { authGuard } from './guards/auth.guard';




const routes: Routes = [

  // { path: 'client', loadChildren: () => import('./client/client.module').then(m => m.ClientModule) },
  { path: 'client', loadChildren: () => import('./client/client.module').then(m => m.ClientModule) },
  { path: 'admin', loadChildren: () => import('./admin/admin.module').then(m => m.AdminModule), canActivate:[authGuard] },
   { path: '', redirectTo: '/client', pathMatch: 'full' },
   { path: '**', redirectTo: '/client' } 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
