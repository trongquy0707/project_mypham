import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ServicesService } from 'src/app/admin/admin-services/services.service';
import { ChucVu } from 'src/app/Models/ChucVu';
// import { ChucVu } from 'src/app/admin/Models/ChucVu';


@Component({
  selector: 'app-hienthichucvu',
  templateUrl: './hienthichucvu.component.html',
  styleUrls: ['./hienthichucvu.component.css'],
})
export class HienthichucvuComponent implements OnInit {
  chucvu: ChucVu[] = [];
  constructor(private service: ServicesService, private rout: Router) {}

  ngOnInit(): void {
    this.loadtrang();
  }
  loadtrang() {
    this.service.getchucvu().subscribe((data) => {
      this.chucvu = data;
    });
  }

  xoachucvus(maChucvu: number): void {
    const confirmed = window.confirm('Bạn có muốn xóa chức vụ này không?');
    if (confirmed) {
      this.service.xoachucvu(maChucvu).subscribe({
        complete: () => {
          console.log('Xóa thành công (không có phản hồi)');
          window.location.reload();
        },
      });
    }
  }
}
