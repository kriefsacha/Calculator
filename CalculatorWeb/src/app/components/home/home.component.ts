import { Component, OnInit } from '@angular/core';
import { HistoryService } from 'src/app/services/history/history.service';
import { History } from 'src/app/models/history/history-model';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {
  historyData: History[] = [];
  constructor(private historyService: HistoryService) {}

  ngOnInit(): void {
    this.historyData = this.historyService.getHistory();
  }

  onCalculated(history: History) {
    this.historyService.setNewHistoryLine(history);
    this.historyData = this.historyService.getHistory();
  }
}
