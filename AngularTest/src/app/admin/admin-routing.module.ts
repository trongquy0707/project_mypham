import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './admin.component';
import { HienthiComponent } from './menu/danhmuc/hienthi/hienthi.component';
import { ThemmoiComponent } from './menu/danhmuc/themmoi/themmoi.component';
import { SuadanhmucComponent } from './menu/danhmuc/suadanhmuc/suadanhmuc.component';
import { HienthichucvuComponent } from './menu/chucvu/hienthichucvu/hienthichucvu.component';
import { SuachucvuComponent } from './menu/chucvu/suachucvu/suachucvu.component';
import { ThemmoichucvuComponent } from './menu/chucvu/themmoichucvu/themmoichucvu.component';
import { HienthisanphamComponent } from './menu/sanphamchitiet/hienthisanpham/hienthisanpham.component';
import { SuasanphamComponent } from './menu/sanphamchitiet/suasanpham/suasanpham.component';
import { ThemmoisanphamComponent } from './menu/sanphamchitiet/themmoisanpham/themmoisanpham.component';
import { authGuard } from '../guards/auth.guard';
import { HienthidonhangComponent } from './menu/donhang/hienthidonhang/hienthidonhang.component';
import { DetailOrderComponent } from './menu/donhang/detail-order/detail-order.component';
import { XacnhandonhangComponent } from './menu/donhang/xacnhandonhang/xacnhandonhang.component';
import { ChoxacnhanComponent } from './menu/donhang/choxacnhan/choxacnhan.component';
import { AlltaikhoanComponent } from './menu/taikhoan/alltaikhoan/alltaikhoan.component';

const routes: Routes = [
  {
    // path:'', component:AdminComponent,
     path:'', component:AdminComponent,canActivate:[authGuard],
    children:[
      {path:'hienthidanhmuc', component:HienthiComponent},
      {path:'themmoi', component:ThemmoiComponent},
      {path:'suadanhmuc/:maDanhMuc', component:SuadanhmucComponent},
       {path:'hienthichucvu', component:HienthichucvuComponent},
       {path:'suachucvu/:maChucVu', component:SuachucvuComponent},
       {path:'themoichucvu', component: ThemmoichucvuComponent},
       {path:'HienthiSanPham', component: HienthisanphamComponent},
      {path:'suasanpham/:maSP', component: SuasanphamComponent},
      {path:'themmoisanpham', component: ThemmoisanphamComponent},
      {path:'hienthidonhang', component: HienthidonhangComponent},
      {path:'detailOrder/:maHD',component:DetailOrderComponent},
      {path:'xacnhandonhang',component:ChoxacnhanComponent},
      {path:'taikhoan',component:AlltaikhoanComponent}
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
