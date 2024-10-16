import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ClientRoutingModule } from './client-routing.module';
import { ClientComponent } from './client.component';

import { HttpClientModule } from '@angular/common/http';
import { HienthidanhmucComponent } from './menu/danhmuc/hienthidanhmuc/hienthidanhmuc.component';
import { HomeComponent } from './menu/home/home/home.component';
import { ProductcategoryComponent } from './menu/home/productcategory/productcategory.component';
import { ProductdetailComponent } from './menu/home/productdetail/productdetail.component';
import { FlashsaleComponent } from './menu/home/flashsale/flashsale.component';
import { NgxPaginationModule } from 'ngx-pagination';
import { GioithieuComponent } from './menu/home/gioithieu/gioithieu.component';
import { AllProductComponent } from './menu/home/all-product/all-product.component';
import { ShowcartComponent } from './menu/Cart/showcart/showcart.component';
import { CheckoutComponent } from './menu/Cart/checkout/checkout.component';
import { FormsModule } from '@angular/forms';

import { ReurtnnvnpayComponent } from './menu/Cart/reurtnnvnpay/reurtnnvnpay.component';
import { ReturnfailComponent } from './menu/Cart/returnfail/returnfail.component';
import { ProductcheckoutComponent } from './menu/Cart/productcheckout/productcheckout.component';
import { LogginComponent } from './menu/account/loggin/loggin.component';
import { RegisterComponent } from './menu/account/register/register.component';





@NgModule({
  declarations: [
    ClientComponent,
    
    HienthidanhmucComponent,
    HomeComponent,
    ProductcategoryComponent,
    ProductdetailComponent,
    FlashsaleComponent,
    GioithieuComponent,
    AllProductComponent,
    ShowcartComponent,
    CheckoutComponent,
    
    ReurtnnvnpayComponent,
         ReturnfailComponent,
         ProductcheckoutComponent,
         LogginComponent,
         RegisterComponent,

 
  
  ],
  imports: [
    CommonModule,
    ClientRoutingModule,
    HttpClientModule,
    NgxPaginationModule,
    FormsModule
  ]
})
export class ClientModule { }
