import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})

export class HomeComponent {
  public employees: EmployeeSummary[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<EmployeeSummary[]>(baseUrl + 'employee').subscribe(result => {
      this.employees = result;
    }, error => console.error(error));
  }
}

interface EmployeeSummary {
  id: string,
  position: string;
  fullName: string;
  salary: string;
  hireDate: string;
  fireDate: string;
}
