import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ThemmoiComponent } from './themmoi.component';

describe('ThemmoiComponent', () => {
  let component: ThemmoiComponent;
  let fixture: ComponentFixture<ThemmoiComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ThemmoiComponent]
    });
    fixture = TestBed.createComponent(ThemmoiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
