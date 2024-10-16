import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { AdminRoutingModule } from './admin-routing.module';
import { AdminComponent } from './admin.component';

import { FooterComponent } from './layout/footer/footer.component';
import { SidebarComponent } from './layout/sidebar/sidebar.component';
import { TopbarComponent } from './layout/topbar/topbar.component';
import { HienthiComponent } from './menu/danhmuc/hienthi/hienthi.component';
import { ThemmoiComponent } from './menu/danhmuc/themmoi/themmoi.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SuadanhmucComponent } from './menu/danhmuc/suadanhmuc/suadanhmuc.component';
import { HienthichucvuComponent } from './menu/chucvu/hienthichucvu/hienthichucvu.component';
import { SuachucvuComponent } from './menu/chucvu/suachucvu/suachucvu.component';
import { ThemmoichucvuComponent } from './menu/chucvu/themmoichucvu/themmoichucvu.component';
import { ThemmoisanphamComponent } from './menu/sanphamchitiet/themmoisanpham/themmoisanpham.component';
import { HienthisanphamComponent } from './menu/sanphamchitiet/hienthisanpham/hienthisanpham.component';
import { SuasanphamComponent } from './menu/sanphamchitiet/suasanpham/suasanpham.component';
import { NgxPaginationModule } from 'ngx-pagination';
import { CKEditorModule } from '@ckeditor/ckeditor5-angular';
import { TruncatePipe } from './tomtat/truncate.pipe';
import { HienthihinhanhComponent } from './menu/hinhanh/hienthihinhanh/hienthihinhanh.component';
import { MatDialogModule } from '@angular/material/dialog';
import { HienthidonhangComponent } from './menu/donhang/hienthidonhang/hienthidonhang.component';
import { DetailOrderComponent } from './menu/donhang/detail-order/detail-order.component';
import { ListOrderComponent } from './menu/donhang/list-order/list-order.component';
import { XacnhandonhangComponent } from './menu/donhang/xacnhandonhang/xacnhandonhang.component';

import { Chart } from 'chart.js';
import { ChoxacnhanComponent } from './menu/donhang/choxacnhan/choxacnhan.component';
import { AlltaikhoanComponent } from './menu/taikhoan/alltaikhoan/alltaikhoan.component';




@NgModule({
  declarations: [
    AdminComponent,
    FooterComponent,
    SidebarComponent,
    TopbarComponent,
    HienthiComponent,
    ThemmoiComponent,
    SuadanhmucComponent,
    HienthichucvuComponent,
    SuachucvuComponent,
    ThemmoichucvuComponent,
    ThemmoisanphamComponent,
    HienthisanphamComponent,
    SuasanphamComponent,
    TruncatePipe,
    HienthihinhanhComponent,
    HienthidonhangComponent,
    DetailOrderComponent,
    ListOrderComponent,
    XacnhandonhangComponent,
    ChoxacnhanComponent,
    AlltaikhoanComponent,
   
   
  
    
    
  ],
  imports: [CommonModule, 
    AdminRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    NgxPaginationModule ,
     CKEditorModule,
    MatDialogModule,
    
  ],
})
export class AdminModule {}
