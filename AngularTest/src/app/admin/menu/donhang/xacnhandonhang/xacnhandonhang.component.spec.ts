import { ComponentFixture, TestBed } from '@angular/core/testing';

import { XacnhandonhangComponent } from './xacnhandonhang.component';

describe('XacnhandonhangComponent', () => {
  let component: XacnhandonhangComponent;
  let fixture: ComponentFixture<XacnhandonhangComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [XacnhandonhangComponent]
    });
    fixture = TestBed.createComponent(XacnhandonhangComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
