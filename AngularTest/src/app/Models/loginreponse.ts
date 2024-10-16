export interface loginreponse {
    success: boolean;
    message: string;
    taikhoan: {
      maUser: number;
      tenDangNhap: string;
      email: string;
      sdt: string | null;
      maChucVu: number;
    };
    token:string;
}