import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-information',
  templateUrl: './information.component.html',
  styleUrls: ['./information.component.css']
})


export class InformationComponent {
  // id = new FormControl('');
  // name = new FormControl('');

  // information = new FormGroup({
  //   id: new FormControl(''),
  //   name: new FormControl(''),
  //   address: new FormGroup({
  //     province: new FormControl(''),
  //     city: new FormControl(''),
  //     county: new FormControl('')
  //   })// 嵌套formgroup
  // });

  informations = this.fb.group({
    id: ['', Validators.required],
    name: [''],
    address: this.fb.group({
      province: [''],
      city: [''],
      county: ['']
    })
  });

  constructor(private fb: FormBuilder) { }

  // updateName() {
  //   this.name.setValue('John');
  // }
  // updateInformation() {
  //   this.information.patchValue({
  //     id: 5,
  //     name: 'wang',
  //     address: {
  //       province: '四川'
  //     }
  //   });
  // }

  onSubmit() {
    console.log(this.informations.value);
  }
}
