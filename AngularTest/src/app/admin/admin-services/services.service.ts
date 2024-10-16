import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Observer, reduce, tap } from 'rxjs';
import { DanhMuc } from 'src/app/Models/DanhMuc';
import { ChucVu } from 'src/app/Models/ChucVu'; 
import { ReturnStatement } from '@angular/compiler';
import { SanPhamChiTiet } from 'src/app/Models/SanPhamChiTiet'; 
import { hinhanh } from 'src/app/Models/hinhanh'; 
import { hoadon } from 'src/app/Models/hoadon';
import { hoadonchitiet } from 'src/app/Models/hoadonchitiet';
import { taikhoan } from 'src/app/Models/taikhoan';


@Injectable({
  providedIn: 'root'
})
export class ServicesService {
private apiUrl='https://localhost:44353/api';
  constructor(private http: HttpClient) { }
   private getToken(): string | null {
    return localStorage.getItem('token');
  }

  // Phương thức để tạo header kèm token
  private getAuthHeaders() {
    const token = this.getToken();
    return token ? new HttpHeaders().set('Authorization', `Bearer ${token}`) : new HttpHeaders();
  }
  
  // Danh Muc
  getCategory(): Observable<DanhMuc[]>{
    const headers = this.getAuthHeaders();
      return this.http.get<DanhMuc[]>(`${this.apiUrl}/DanhMucSanPham/getAll`,{headers});
  }
  getbyid(id: number){
    const headers = this.getAuthHeaders();
    return this.http.get<DanhMuc>(`${this.apiUrl}/DanhMucSanPham/getbyId/${id}`,{headers});
  }
  themmoi(formData: FormData){
    const headers = this.getAuthHeaders();
    return this.http.post(`${this.apiUrl}/DanhMucSanPham/ThemMoiDanhMuc`, formData,{headers}).pipe(
      tap(response=>{
        console.log('API response:', response);
      })
    );
  }
  suadanhmuc(id:number, formData: FormData ){
    return this.http.post(`${this.apiUrl}/DanhMucSanPham/SuaDanhMuc/${id}`, formData , {responseType:'text'});
  }
  xoadanhmuc(id:number): Observable<any>{

    return this.http.delete(`${this.apiUrl}/DanhMucSanPham/XoaDanhMuc/${id}`, {responseType:'text'});
  }

  //Chuc VU
  getchucvu(): Observable<ChucVu[]>{
    const headers = this.getAuthHeaders();
    return this.http.get<ChucVu[]>(`${this.apiUrl}/ChucVu/Getall`,{headers});
  };
   getbychucvuid(id:number){
    return this.http.get<ChucVu>(`${this.apiUrl}/ChucVu/getbyidchucvu/${id}`);
   };

   suachucvu( id: number, data: ChucVu){
    return this.http.post(`${this.apiUrl}/ChucVu/suachucvu/${id}`, data, {responseType:'text'});
   };

   xoachucvu(id: number): Observable<any>{
    return this.http.delete(`${this.apiUrl}/ChucVu/xoachucvu/${id}`, {responseType:'text'})
   };
   themchuvu(data: ChucVu){
    return this.http.post(`${this.apiUrl}/ChucVu/themoi`, data);
   }

   //sanphamchitiet
   getsanphamchitiet():Observable<SanPhamChiTiet[]>{
    const headers = this.getAuthHeaders();
    return this.http.get<SanPhamChiTiet[]>(`${this.apiUrl}/SanPhamChiTiet/getall`, {headers});
   }
   suasanpham(id:number, formData: FormData){
    const headers = this.getAuthHeaders();
    return this.http.post(`${this.apiUrl}/SanPhamChiTiet/suasanpham/${id}`,formData,{responseType:'text',headers});
   }
   getbyidsanpham(id:number){
    const headers = this.getAuthHeaders();
    return this.http.get<SanPhamChiTiet>(`${this.apiUrl}/SanPhamChiTiet/getbyID/${id}`,{headers});
   }
   ishome(id:number){
    const headers = this.getAuthHeaders();
    return this.http.post(`${this.apiUrl}/SanPhamChiTiet/isHome/${id}`,{responseType:'text'},{headers})
   }
   issale(id: number){
    const headers = this.getAuthHeaders();
    return this.http.post(`${this.apiUrl}/SanPhamChiTiet/issale/${id}`,{responseType:'text'},{headers})
   }


  xoasanpham(id:number): Observable<any> {
   return this.http.delete(`${this.apiUrl}/SanPhamChiTiet/xoasanpham/${id}`, {responseType:'text'})
  };
  //tesst
  themsanpham(formData: FormData){
    const headers = this.getAuthHeaders();
    return this.http.post(`${this.apiUrl}/SanPhamChiTiet/themmoitesst`, formData,{headers}).pipe(
      tap(response=>{
        console.log('API response:', response);
      })
    )
   };

   //hinhanh
  hienthihinhanh(id:number){
    return this.http.get<hinhanh>(`${this.apiUrl}/HinhAnh/getall/${id}`);
  };
  xoaanh(id:number){
    return this.http.delete(`${this.apiUrl}/HinhAnh/xoaanh/${id}`,{responseType:'text'})
  }
   //hoadon
   hienthiHoaDon():Observable<hoadon[]>{
    const headers = this.getAuthHeaders();
    return this.http.get<hoadon[]>(`${this.apiUrl}/HoaDon/getallHoaDon`,{headers});
   }
   detailOrder(id:any):Observable<hoadon>{
    return this.http.get<hoadon>(`${this.apiUrl}/HoaDon/detailOrder/${id}`);
   }
   listOrder(id:any):Observable<hoadonchitiet[]>{
    return this.http.get<hoadonchitiet[]>(`${this.apiUrl}/HoaDon/ListOrder/${id}`);
   }
   trangthaidonhang(formData: FormData){
   
    return this.http.post(`${this.apiUrl}/HoaDon/CapnhatTT`, formData);
   }
   xacnhadonhang():Observable<hoadon[]>{
    return this.http.get<hoadon[]>(`${this.apiUrl}/HoaDon/choxacnhan`);
   }

   xacnhanall(){
    return this.http.post(`${this.apiUrl}/HoaDon/xacnhanall`,{responseType:'text'});
   }

   getalltaikhoan():Observable<taikhoan[]>{
    const headers = this.getAuthHeaders();
    return this.http.get<taikhoan[]>(`${this.apiUrl}/ChucVu/getalltaikhoan`,{headers});
   }
   
   capquyen(formData:FormData){
    const headers = this.getAuthHeaders();
    return this.http.post(`${this.apiUrl}/ChucVu/capquyen`,formData,{headers});
   }
}
