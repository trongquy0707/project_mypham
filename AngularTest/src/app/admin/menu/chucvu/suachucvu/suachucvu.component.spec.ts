import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SuachucvuComponent } from './suachucvu.component';

describe('SuachucvuComponent', () => {
  let component: SuachucvuComponent;
  let fixture: ComponentFixture<SuachucvuComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SuachucvuComponent]
    });
    fixture = TestBed.createComponent(SuachucvuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
