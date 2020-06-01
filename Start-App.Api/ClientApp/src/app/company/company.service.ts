import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpErrorHandler, HandleError } from '../http-error-handler.service';
import { Observable } from 'rxjs';
import { Company } from '../models/company';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class CompanyService {
  private handleError: HandleError;

  constructor(private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string,
    httpErrorHandler: HttpErrorHandler) {
    this.handleError = httpErrorHandler.createHandleError('CompanyService');

  }

  getCompanies(): Observable<Array<Company>> {
    return this.http.get<Company[]>(this.baseUrl + 'api/companies')
      .pipe(catchError(this.handleError('getCompanies', [])));
  }

  getCompany(companyId: string): Observable<Company> {
    return this.http.get<Company>(this.baseUrl + 'api/companies/' + companyId)
      .pipe(catchError(this.handleError('getCompany', company)));
  }

  addCompany(): Observable<Company> {
    return this.http.post<Company>(this.baseUrl + 'api/companies/')
  }
}
