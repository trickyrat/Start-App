import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Employee } from '../models/employee';
import { HandleError, HttpErrorHandler } from './http-error-handler.service';
import { Observable, BehaviorSubject } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  private handleError: HandleError;
  employees: Employee[];
  options = {
    params: new HttpParams()
      .set("pageIndex", '1')
      .set("pageSize", '10'),
  };
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string,
    httpErrorHandler: HttpErrorHandler) {
    this.handleError = httpErrorHandler.createHandleError('EmployeeService');
  }

  getEmployees(pageIndex?: number, pageSize?: number): Observable<Employee[]> {
    if (pageIndex != null && pageSize != null) {
      this.options.params.set("pageIndex", pageIndex.toString()).set("pageSize", pageSize.toString());
    }
    return this.http.get<Employee[]>(this.baseUrl + 'api/employees', this.options)
      .pipe(catchError(this.handleError('getEmployees', [])));
  }
}
