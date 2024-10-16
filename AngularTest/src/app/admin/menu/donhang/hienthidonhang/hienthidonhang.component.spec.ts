import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HienthidonhangComponent } from './hienthidonhang.component';

describe('HienthidonhangComponent', () => {
  let component: HienthidonhangComponent;
  let fixture: ComponentFixture<HienthidonhangComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [HienthidonhangComponent]
    });
    fixture = TestBed.createComponent(HienthidonhangComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
