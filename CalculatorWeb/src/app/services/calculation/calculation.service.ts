import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { CalculateModel } from 'src/app/models/calculator/calculate-model';

@Injectable({
  providedIn: 'root',
})
export class CalculationService {
  apiUrl = environment.apiUrl + 'Calculation/';
  constructor(private http: HttpClient) {}

  calculate(model: CalculateModel): Observable<number> {
    return new Observable((observer) => {
      console.log(model)
      var subscription = this.http
        .post(this.apiUrl + 'calculate' , model)
        .subscribe({ next: (res) => {
          observer.next(res as number);
          subscription.unsubscribe();
        }, error: (err) => {
          console.log(err);
          subscription.unsubscribe();
          observer.error(err);
        } });
    });
  }
}
