import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReturnfailComponent } from './returnfail.component';

describe('ReturnfailComponent', () => {
  let component: ReturnfailComponent;
  let fixture: ComponentFixture<ReturnfailComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ReturnfailComponent]
    });
    fixture = TestBed.createComponent(ReturnfailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
