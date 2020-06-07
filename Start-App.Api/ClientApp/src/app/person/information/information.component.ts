import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { startWith, map } from 'rxjs/operators';

@Component({
  selector: 'app-information',
  templateUrl: './information.component.html',
  styleUrls: ['./information.component.css']
})


export class InformationComponent implements OnInit {
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
    // informations = this.fb.group({
  //   id: ['', Validators.required],
  //   name: [''],
  //   address: this.fb.group({
  //     province: [''],
  //     city: [''],
  //     county: ['']
  //   })
  // });

  myControl = new FormControl();
  options: string[] = ['One', 'Two', 'Three'];
  filteredOptions: Observable<string[]>;

  private _filter(value: string): string[] {
    const filterValue = value.toLowerCase();
    return this.options.filter(option => option.toLowerCase().indexOf(filterValue) === 0);
  }
  ngOnInit() {
    this.filteredOptions = this.myControl.valueChanges.pipe(
      startWith(''),
      map(value => this._filter(value))
    );
  }

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

  // onSubmit() {
  //   console.log(this.informations.value);
  // }
}
