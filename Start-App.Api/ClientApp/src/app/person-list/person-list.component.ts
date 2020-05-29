import { Component } from '@angular/core';
import { PersonService } from '../person/person.service';
import { Person } from '../models/Person';

@Component({
  selector: 'app-person-list',
  templateUrl: './person-list.component.html',
  styleUrls: ['./person-list.component.css']
})
export class PersonListComponent {
  people: Person[];
  constructor(personService: PersonService) {
    this.people = personService.getPeople();
  }
}
