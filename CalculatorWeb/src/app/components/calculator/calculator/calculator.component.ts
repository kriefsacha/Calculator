import { Component, EventEmitter, OnInit, Output, ViewChild } from '@angular/core';
import { CalculateModel } from 'src/app/models/calculator/calculate-model';
import { History } from 'src/app/models/history/history-model';
import { CalculationService } from 'src/app/services/calculation/calculation.service';
import { OperationComponent } from '../operation/operation.component';

@Component({
  selector: 'app-calculator',
  templateUrl: './calculator.component.html',
  styleUrls: ['./calculator.component.scss'],
})
export class CalculatorComponent implements OnInit {
  clearDeleteValues: string[] = [];
  numbersValues: string[] = [];
  operatorsValues: string[] = [];
  @ViewChild(OperationComponent, { static: false })
  operationComponent?: OperationComponent;
  @Output() onCalculated = new EventEmitter<History>();

  constructor(private calculationService: CalculationService) {}

  ngOnInit(): void {
    this.clearDeleteValues = ['CLEAR', 'DELETE'];
    this.operatorsValues = ['+', '-', '*', '/'];
    this.numbersValues = [
      '7',
      '8',
      '9',
      '4',
      '5',
      '6',
      '1',
      '2',
      '3',
      '.',
      '0',
      '=',
    ];
  }

  onButtonCalculatorClick(event: string) {
    let lastCharacter = this.operationComponent?.currentOperation.slice(-1);

    if (new RegExp(/[0-9]/).test(event)) {
      this.operationComponent?.addValueCurrentOperation(event);
    }
    else if(event === '+' || event === '-' || event === '*' || event === '/') {
      if(lastCharacter !== '+' && lastCharacter !== '-' && lastCharacter !== '*' && lastCharacter !== '/'){
        this.operationComponent?.addValueCurrentOperation(event);
      }
    }
    else if (event === '.') {
      if (this.operationComponent?.currentOperation !== '') {
        if (lastCharacter === '.') return;
      } else this.operationComponent?.addValueCurrentOperation('.');
    } else if (event === 'CLEAR') {
      this.operationComponent?.clear();
    } else if (event === 'DELETE') {
      this.operationComponent?.delete();
    } else if (event === '=') {
      this.calculate();
    }
  }

  calculate() {
    let model = new CalculateModel();
    model.expression = this.operationComponent?.currentOperation as string;
    this.calculationService.calculate(model).subscribe({next: (res) => {
      if(this.operationComponent != undefined)
        this.operationComponent.currentOperation = res.toString();

      this.setHistory(model.expression, res);
    },
  error: (err) => {
    console.log(err);
    alert("An error happened ! : " + err.error);
  }})
  }

  setHistory(operation: string, result: number) {
    let history = new History();
    history.date = new Date();
    history.operation = operation;
    history.result = result;
    this.onCalculated.emit(history);
  }
}
