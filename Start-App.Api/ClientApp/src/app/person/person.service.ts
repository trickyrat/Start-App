import { Injectable, Inject } from '@angular/core';
import { Person } from '../models/Person';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})

export class PersonService {
  People: Person[];
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Person[]>(baseUrl + 'api/people').subscribe(result => {
      this.People = result;
    }, error => console.log(error));
  }

  getPeople(): Person[] {
    return this.People;
  }
}
