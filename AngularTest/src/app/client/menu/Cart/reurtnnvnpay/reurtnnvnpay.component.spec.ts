import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReurtnnvnpayComponent } from './reurtnnvnpay.component';

describe('ReurtnnvnpayComponent', () => {
  let component: ReurtnnvnpayComponent;
  let fixture: ComponentFixture<ReurtnnvnpayComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ReurtnnvnpayComponent]
    });
    fixture = TestBed.createComponent(ReurtnnvnpayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
