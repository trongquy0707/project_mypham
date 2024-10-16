import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HienthihinhanhComponent } from './hienthihinhanh.component';

describe('HienthihinhanhComponent', () => {
  let component: HienthihinhanhComponent;
  let fixture: ComponentFixture<HienthihinhanhComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [HienthihinhanhComponent]
    });
    fixture = TestBed.createComponent(HienthihinhanhComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
