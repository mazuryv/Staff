import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DataService } from './../data.service';
import { Position } from './../position';

@Component({
  selector: 'add-position-popup',
  templateUrl: './popup.component.html',
  providers: [DataService]
})

export class AddPositionPopupComponent {
  showModal: boolean;
  addNewPositionForm: FormGroup;
  position: Position = new Position();
  submitted = false;
  constructor(private dataService: DataService, private formBuilder: FormBuilder) {}
  show() {
    this.showModal = true;
  }
  hide() {
    this.showModal = false;
  }
  ngOnInit() {
    this.addNewPositionForm = this.formBuilder.group({
      description: ['', [Validators.required]]
    });
    
  }
  get controls() { return this.addNewPositionForm.controls; }
  onSubmit() {
    this.submitted = true;
    if (this.addNewPositionForm.invalid) {
      return;
    }
    this.position.description = this.controls.description.value;
    this.dataService.createPosition(this.position)
      .subscribe(result => {
        this.showModal = false;
        this.submitted = false;
        this.controls.description.setValue('');
      }, error => console.error(error));
  }
}
