import { Component, EventEmitter, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { EmployeeDataService } from './../data.service';
import { Employee } from './../employee';
import { PositionDataService } from './../../positions/data.service';
import { Position } from './../../positions/position';

@Component({
  selector: 'add-employee-popup',
  templateUrl: './popup.component.html',
  providers: [EmployeeDataService, PositionDataService]
})

export class AddEmployeePopupComponent {
  showModal: boolean;
  addNewEmployeeForm: FormGroup;
  employee: Employee = new Employee();
  positions: Position[];
  submitted = false;
  constructor(private dataService: EmployeeDataService, private positionDataService: PositionDataService, private formBuilder: FormBuilder) {}
  show() {
    this.showModal = true;
  }
  hide() {
    this.showModal = false;
  }
  ngOnInit() {
    this.positionDataService.getPositions()
      .subscribe((data: Position[]) => {
        this.positions = data;
      }, error => console.error(error));

    this.addNewEmployeeForm = this.formBuilder.group({
      lastName: ['', [Validators.required]],
      firstName: ['', [Validators.required]],
      position: ['', [Validators.required]],
      salary: ['', [Validators.required]],
      hireDate: ['', [Validators.required]],
      fireDate: ['']
    });
  }
  get controls() { return this.addNewEmployeeForm.controls; }
  @Output() onChanged = new EventEmitter<boolean>();
  onSubmit() {
    this.submitted = true;
    if (this.addNewEmployeeForm.invalid) {
      return;
    }
    this.dataService.createEmployee(this.employee)
      .subscribe(result => {
        this.showModal = false;
        this.submitted = false;
        this.employee = new Employee();
        this.onChanged.emit();
      }, error => console.error(error));
  }
}
