import { Injectable, Inject } from '@angular/core';
import { Person } from '../models/Person';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { HandleError, HttpErrorHandler } from '../http-error-handler.service';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
    'Authorization': 'blabla...'
  })
};


@Injectable({
  providedIn: 'root'
})

export class PersonService {
  private handleError: HandleError;
  private baseUrl: string;

  People: Person[];
  constructor(private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    httpErrorHandler: HttpErrorHandler) {
    this.handleError = httpErrorHandler.createHandleError('PersonService');
    this.baseUrl = baseUrl + 'api/people';
  }

  getPeople(): Observable<Person[]> {
    return this.http.get<Person[]>(this.baseUrl)
      .pipe(
        catchError(this.handleError('getPeople', []))
      );
  }

  searchPerson(term: string): Observable<Person[]> {
    term = term.trim();
    const options = term ? { params: new HttpParams().set('name', term) } : {};
    return this.http.get<Person[]>(this.baseUrl, options)
      .pipe(
        catchError(this.handleError<Person[]>('searchPerson', []))
      );
  }

  addPerson(person: Person): Observable<Person> {
    return this.http.post<Person>(this.baseUrl, person, httpOptions)
      .pipe(
        catchError(this.handleError('addPerson', person))
      );
  }

  updatePerson(person: Person): Observable<Person> {
    httpOptions.headers =
      httpOptions.headers.set('Authorization', 'blabla..');
    return this.http.put<Person>(this.baseUrl, person, httpOptions)
      .pipe(
        catchError(this.handleError('updatePerson', person))
      );
  }

  deletePerson(id: number): Observable<{}> {
    const url = `${this.baseUrl}/${id}`;
    return this.http.delete(url, httpOptions)
      .pipe(
        catchError(this.handleError('deletePerson'))
      );
  }


}
