import { Injectable } from '@angular/core';
import { History } from 'src/app/models/history/history-model';

@Injectable({
  providedIn: 'root',
})
export class HistoryService {
 localStorageKey = "calculatorHistory";
  constructor() {}

  setNewHistoryLine(line: History) {
    let history: History[] = [];
    let historyString = localStorage.getItem(this.localStorageKey);
    if (historyString != null) history = JSON.parse(historyString);
    
    history.push(line);
    localStorage.setItem(this.localStorageKey,JSON.stringify(history));
  }

  getHistory(): History[] {
    let history: History[] = [];
    let historyString = localStorage.getItem(this.localStorageKey);
    if (historyString != null) history = JSON.parse(historyString);
    history = this.orderByDate(history);
    history = this.getFirstTen(history);
    return history;    
  }

  orderByDate(history: History[]): History[] {
    return history.sort((a,b) => {
      return new Date(b.date).getTime() - new Date(a.date).getTime();
    })
  }

  getFirstTen(history: History[]):History[] {
    return history.slice(0,10);
  }
}
