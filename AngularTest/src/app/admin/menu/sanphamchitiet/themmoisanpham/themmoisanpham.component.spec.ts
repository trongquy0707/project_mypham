import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ThemmoisanphamComponent } from './themmoisanpham.component';

describe('ThemmoisanphamComponent', () => {
  let component: ThemmoisanphamComponent;
  let fixture: ComponentFixture<ThemmoisanphamComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ThemmoisanphamComponent]
    });
    fixture = TestBed.createComponent(ThemmoisanphamComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
