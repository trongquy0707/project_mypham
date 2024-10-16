import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SuadanhmucComponent } from './suadanhmuc.component';

describe('SuadanhmucComponent', () => {
  let component: SuadanhmucComponent;
  let fixture: ComponentFixture<SuadanhmucComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SuadanhmucComponent]
    });
    fixture = TestBed.createComponent(SuadanhmucComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
