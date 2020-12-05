import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public forecasts: EmployeeSummary[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<EmployeeSummary[]>(baseUrl + 'employee').subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));
  }
}

interface EmployeeSummary {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
