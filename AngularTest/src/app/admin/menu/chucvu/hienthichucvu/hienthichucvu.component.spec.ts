import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HienthichucvuComponent } from './hienthichucvu.component';

describe('HienthichucvuComponent', () => {
  let component: HienthichucvuComponent;
  let fixture: ComponentFixture<HienthichucvuComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [HienthichucvuComponent]
    });
    fixture = TestBed.createComponent(HienthichucvuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
