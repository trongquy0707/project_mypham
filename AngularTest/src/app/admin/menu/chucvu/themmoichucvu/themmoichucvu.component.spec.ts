import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ThemmoichucvuComponent } from './themmoichucvu.component';

describe('ThemmoichucvuComponent', () => {
  let component: ThemmoichucvuComponent;
  let fixture: ComponentFixture<ThemmoichucvuComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ThemmoichucvuComponent]
    });
    fixture = TestBed.createComponent(ThemmoichucvuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
