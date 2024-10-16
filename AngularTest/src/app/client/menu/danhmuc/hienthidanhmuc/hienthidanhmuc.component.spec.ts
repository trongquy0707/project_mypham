import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HienthidanhmucComponent } from './hienthidanhmuc.component';

describe('HienthidanhmucComponent', () => {
  let component: HienthidanhmucComponent;
  let fixture: ComponentFixture<HienthidanhmucComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [HienthidanhmucComponent]
    });
    fixture = TestBed.createComponent(HienthidanhmucComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
