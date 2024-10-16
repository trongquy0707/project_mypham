import { HttpClient, HttpClientModule, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Form } from '@angular/forms';
import { Observable, Observer } from 'rxjs';
import { DanhMuc } from 'src/app/Models/DanhMuc'; 
import { hinhanh } from 'src/app/Models/hinhanh';
import { loginreponse } from 'src/app/Models/loginreponse';
import { returnVnPay } from 'src/app/Models/reurnnVnpay';
import { SanPhamChiTiet } from 'src/app/Models/SanPhamChiTiet';
import { ShoppingCartItem } from 'src/app/Models/ShoppingCartItem';

@Injectable({
  providedIn: 'root'
})
export class ClientservicesService {

  private apiUrl='https://localhost:44353/api';
  constructor(private http:HttpClient) { }
  // danhmuc
   getallCategory():Observable<DanhMuc[]>{
    return this.http.get<DanhMuc[]>(`${this.apiUrl}/DanhMuc/getallCategory`);

   }  

   //sanpham
   GetProductCategory(maDanhMuc: number):Observable<SanPhamChiTiet[]>{
    return this.http.get<SanPhamChiTiet[]>(`${this.apiUrl}/SanPham/sanphamtheodanhmuc/${maDanhMuc}`);
   }
   getproductdetail(maSP: number): Observable<SanPhamChiTiet> {
    return this.http.get<SanPhamChiTiet>(`${this.apiUrl}/SanPham/chitietsanpham/${maSP}`);
  }
   getImageProduct(maSP:number):Observable<hinhanh[]>{
    return this.http.get<hinhanh[]>(`${this.apiUrl}/HinhAnh/getall/${maSP}`)
   }
   getProductSale():Observable<SanPhamChiTiet[]>{
    return this.http.get<SanPhamChiTiet[]>(`${this.apiUrl}/SanPham/sanphamissale`)
   }
   getProductHome():Observable<SanPhamChiTiet[]>{
    return this.http.get<SanPhamChiTiet[]>(`${this.apiUrl}/SanPham/sanphamishome`)
   }
   getAllProduct(search:string):Observable<SanPhamChiTiet[]>{
    let params = new HttpParams().set('search', search);
    return this.http.get<SanPhamChiTiet[]>(`${this.apiUrl}/SanPham/sanphamchung`,{params});
   }

   //cart
   addToCart(formData: FormData): Observable<any>{
    return this.http.post<any>(`${this.apiUrl}/ShoppingCart/addToCart`,formData,{ withCredentials: true });
   }
   getcart(): Observable<ShoppingCartItem[]>{
    return this.http.get<ShoppingCartItem[]>(`${this.apiUrl}/ShoppingCart/getcart` ,{ withCredentials: true });
   }
   getcount(){
    return this.http.get(`${this.apiUrl}/ShoppingCart/getsoluong` ,{ withCredentials: true });
   }
   xoaItemCart(id: number){
    return this.http.delete(`${this.apiUrl}/ShoppingCart/XoaSP/${id}`,{ withCredentials: true ,responseType:'text'})
   }

   updateQuantity(formData: FormData):Observable<any>{
    return this.http.post<any>(`${this.apiUrl}/ShoppingCart/updateQuantity`,formData, { withCredentials: true })
   }

   checkout(order: FormData):Observable<any>{
    return this.http.post(`${this.apiUrl}/ShoppingCart/CheckOut`, order, { 
      withCredentials: true, 
      responseType: 'text' 
    });
   }

   returnVnPay():Observable<returnVnPay[]>{
    return this.http.get<returnVnPay[]>(`${this.apiUrl}/ShoppingCart/returnVnpay?params`,{withCredentials:true})
   }
//accunt
   loggin(data: FormData):Observable<loginreponse>{
    return this.http.post<loginreponse>(`${this.apiUrl}/Account/loggin`,data);
   }

   register(data:FormData){
    return this.http.post(`${this.apiUrl}/Account/dangky`,data)
   }
   isLoggedIn(): boolean {
    return !!localStorage.getItem('token');
  }

  // Đăng xuất
  logout() {
    localStorage.removeItem('token');
  }

}
