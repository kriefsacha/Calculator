import { Component, Input, OnInit } from '@angular/core';
import { History } from '../../models/history/history-model';
@Component({
  selector: 'app-history',
  templateUrl: './history.component.html',
  styleUrls: ['./history.component.scss'],
})
export class HistoryComponent implements OnInit {
  @Input() historyData: History[] = [];
  constructor() {}

  ngOnInit(): void {}
}
