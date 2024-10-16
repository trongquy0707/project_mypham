import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChoxacnhanComponent } from './choxacnhan.component';

describe('ChoxacnhanComponent', () => {
  let component: ChoxacnhanComponent;
  let fixture: ComponentFixture<ChoxacnhanComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ChoxacnhanComponent]
    });
    fixture = TestBed.createComponent(ChoxacnhanComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
