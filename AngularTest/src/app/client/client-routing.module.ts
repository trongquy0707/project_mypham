import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClientComponent } from './client.component';

import { HomeComponent } from './menu/home/home/home.component';
import { ProductcategoryComponent } from './menu/home/productcategory/productcategory.component';
import { ProductdetailComponent } from './menu/home/productdetail/productdetail.component';
import { AllProductComponent } from './menu/home/all-product/all-product.component';
import { ShowcartComponent } from './menu/Cart/showcart/showcart.component';
import { CheckoutComponent } from './menu/Cart/checkout/checkout.component';
import { ReurtnnvnpayComponent } from './menu/Cart/reurtnnvnpay/reurtnnvnpay.component';
import { ReturnfailComponent } from './menu/Cart/returnfail/returnfail.component';
import { LogginComponent } from './menu/account/loggin/loggin.component';
import { RegisterComponent } from './menu/account/register/register.component';



const routes: Routes = [
  {path:'', component:ClientComponent,
    children:[
      {path:'', component: HomeComponent},
       {path:'sanphamdanhmuc/:maDanhMuc', component:ProductcategoryComponent},
       {path:'productdetail/:maSP', component: ProductdetailComponent},
       {path:'allProduct', component:AllProductComponent},
       {path:'cart', component:ShowcartComponent},
       {path:'checkout', component:CheckoutComponent},
       {path:'returnVnpay', component: ReurtnnvnpayComponent},
       {path:'returnfail', component: ReturnfailComponent},
       {path:'loggin', component: LogginComponent},
       {path:'register',component: RegisterComponent}
       
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ClientRoutingModule { }
