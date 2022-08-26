import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-operation',
  templateUrl: './operation.component.html',
  styleUrls: ['./operation.component.scss'],
})
export class OperationComponent implements OnInit {
  currentOperation: string = '';
  constructor() {}

  ngOnInit(): void {}

  addValueCurrentOperation(value: string) {
    this.currentOperation += value;
  }

  clear() {
    this.currentOperation = "";
  }

  delete() { 
    this.currentOperation = this.currentOperation.slice(0, -1);
  }
}
