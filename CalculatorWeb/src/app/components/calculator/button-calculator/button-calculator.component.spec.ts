import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ButtonCalculatorComponent } from './button-calculator.component';

describe('ButtonCalculatorComponent', () => {
  let component: ButtonCalculatorComponent;
  let fixture: ComponentFixture<ButtonCalculatorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ButtonCalculatorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ButtonCalculatorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
