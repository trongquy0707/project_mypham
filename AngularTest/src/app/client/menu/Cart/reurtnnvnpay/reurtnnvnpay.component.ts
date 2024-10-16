import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ClientservicesService } from 'src/app/client/client-services/clientservices.service';
import { returnVnPay } from 'src/app/Models/reurnnVnpay';

@Component({
  selector: 'app-reurtnnvnpay',
  templateUrl: './reurtnnvnpay.component.html',
  styleUrls: ['./reurtnnvnpay.component.css']
})
export class ReurtnnvnpayComponent implements OnInit {
  vnpAmount: number | null = null;
  vnpTransactionNo: string | null = null;
  vnpTxnRef: string | null = null;
  tenKhachHang:string | null = null;

  constructor(private route: ActivatedRoute) {}

  ngOnInit(): void {
    // Lấy dữ liệu từ URL
    const amountString = this.route.snapshot.queryParamMap.get('vnp_Amount');
    if (amountString) {
      this.vnpAmount = parseFloat(amountString) / 100;
    }
    this.vnpTransactionNo = this.route.snapshot.queryParamMap.get('vnp_TransactionNo');
    this.vnpTxnRef = this.route.snapshot.queryParamMap.get('vnp_TxnRef');
    this.tenKhachHang = this.route.snapshot.queryParamMap.get('tenkhachhang');
  }
}
