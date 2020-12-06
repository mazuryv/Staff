import { Component } from '@angular/core';
import { EmployeeDataService } from './../employees/data.service';
import { EmployeeSummary } from './../employees/employeeSummary';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  providers: [EmployeeDataService]
})

export class HomeComponent {
  public employees: EmployeeSummary[];

  constructor(private dataService: EmployeeDataService) {
    this.loadEmployees();
  }
  onChanged() {
    this.loadEmployees();
  }
  loadEmployees() {
    this.dataService.getEmployees().subscribe((data: EmployeeSummary[]) => {
      this.employees = data;
    }, error => console.error(error));
  }
}
