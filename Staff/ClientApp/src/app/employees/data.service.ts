import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Employee } from './employee';

@Injectable()
export class EmployeeDataService {

  private url;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.url = baseUrl + "employee";
  }

  getEmployees() {
    return this.http.get(this.url);
  }

  getEmployee(id: string) {
    return this.http.get(this.url + '/' + id);
  }

  createEmployee(employee: Employee) {
    return this.http.post(this.url, employee);
  }
  updateEmployeet(employee: Employee) {
    return this.http.put(this.url, employee);
  }
  deleteEmployeet(id: string) {
    return this.http.delete(this.url + '/' + id);
  }
}
