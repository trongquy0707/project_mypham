import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HienthiComponent } from './hienthi.component';

describe('HienthiComponent', () => {
  let component: HienthiComponent;
  let fixture: ComponentFixture<HienthiComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [HienthiComponent]
    });
    fixture = TestBed.createComponent(HienthiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
