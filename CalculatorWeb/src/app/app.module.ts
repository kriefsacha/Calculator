import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { HistoryComponent } from './components/history/history.component';
import { ButtonCalculatorComponent } from './components/calculator/button-calculator/button-calculator.component';
import { OperationComponent } from './components/calculator/operation/operation.component';
import { HomeComponent } from './components/home/home.component';
import { CalculatorComponent } from './components/calculator/calculator/calculator.component';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [AppComponent, HistoryComponent, ButtonCalculatorComponent, OperationComponent, HomeComponent, CalculatorComponent],
  imports: [BrowserModule, HttpClientModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
