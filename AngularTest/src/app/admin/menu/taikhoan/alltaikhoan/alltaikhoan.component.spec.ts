import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AlltaikhoanComponent } from './alltaikhoan.component';

describe('AlltaikhoanComponent', () => {
  let component: AlltaikhoanComponent;
  let fixture: ComponentFixture<AlltaikhoanComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AlltaikhoanComponent]
    });
    fixture = TestBed.createComponent(AlltaikhoanComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
