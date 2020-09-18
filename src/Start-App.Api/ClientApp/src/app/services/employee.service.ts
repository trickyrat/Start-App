import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { BaseService } from './base-service.service';
import { Employee } from "../models/employee";
import { PagedList } from "../models/pagedList";


@Injectable({
  providedIn: 'root'
})
export class EmployeeService
  extends BaseService {
  constructor(
    http: HttpClient,
    @Inject('BASE_URL') baseUrl: string) {
    super(http, baseUrl);
  }

  getData<PagedList>(
    pageIndex: number,
    pageSize: number,
    sortColumn: string,
    sortOrder: string,
    filterColumn: string,
    filterQuery: string): Observable<PagedList> {
    let url = this.baseUrl + 'api/v1/employees';
    let params = new HttpParams()
      .set("pageIndex", pageIndex.toString())
      .set("pageSize", pageSize.toString())
      .set("sortColumn", sortColumn)
      .set("sortOrder", sortOrder);
    if (filterQuery) {
      params = params
        .set("filterColumn", filterColumn)
        .set("sortOrder", sortOrder);
    }
    return this.http.get<PagedList>(url, { params });
  }

  get<Employee>(id: number): Observable<Employee> {
    let url = this.baseUrl + "api/v1/employees/" + id;
    return this.http.get<Employee>(url);
  }

  put<Employee>(employee: Employee): Observable<Employee> {
    let url = this.baseUrl + "api/v1/employees/" + employee;
    return this.http.put<Employee>(url, employee);
  }

  post<Employee>(employee: Employee): Observable<Employee> {
    let url = this.baseUrl + "api/v1/employees";
    return this.http.post<Employee>(url, employee);
  }
}
