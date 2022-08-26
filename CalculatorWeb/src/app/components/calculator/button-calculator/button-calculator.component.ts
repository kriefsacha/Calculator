import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-button-calculator',
  templateUrl: './button-calculator.component.html',
  styleUrls: ['./button-calculator.component.scss'],
})
export class ButtonCalculatorComponent implements OnInit {
  @Input() value: string = '';
  @Output() onClick = new EventEmitter<string>();
  constructor() {}

  ngOnInit(): void {}

  btnClick() {
    this.onClick.emit(this.value);
  }
}
