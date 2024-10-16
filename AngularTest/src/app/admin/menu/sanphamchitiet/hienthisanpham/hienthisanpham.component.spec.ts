import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HienthisanphamComponent } from './hienthisanpham.component';

describe('HienthisanphamComponent', () => {
  let component: HienthisanphamComponent;
  let fixture: ComponentFixture<HienthisanphamComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [HienthisanphamComponent]
    });
    fixture = TestBed.createComponent(HienthisanphamComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
