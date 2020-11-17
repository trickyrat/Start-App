import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { BaseService } from './base-service.service';


export interface IEmployeeDto {
  id?: number;
  nationalIdnumber?: string;
  organizationLevel?: number;
  jobTitle?: string;
  birthDate?: Date;
  maritalStatus?: string;
  gender?: string;
  hireDate?: Date;
  salariedFlag?: boolean;
  vacationHours?: number;
  sickLeaveHours?: number;
  currentFlag?: boolean;
}

export class EmployeeDto implements IEmployeeDto {
  id?: number;
  nationalIdnumber?: string | undefined;
  organizationLevel?: number;
  jobTitle?: string | undefined;
  birthDate?: Date;
  maritalStatus?: string | undefined;
  gender?: string | undefined;
  hireDate?: Date;
  salariedFlag?: boolean;
  vacationHours?: number;
  sickLeaveHours?: number;
  currentFlag?: boolean;
  constructor(data?: IEmployeeDto) {
    if (data) {
      for (let property in data) {
        if (data.hasOwnProperty(property)) {
          (<any>this)[property] = (<any>data)[property];
        }
      }
    }
  }
  init(_data?: any) {
    if (_data) {
      this.id = _data["id"];
      this.nationalIdnumber = _data["nationalIdnumber"];
      this.organizationLevel = _data["organizationLevel"];
      this.jobTitle = _data["jobTitle"];
      this.birthDate = _data["birthDate"];
      this.maritalStatus = _data["maritalStatus"];
      this.gender = _data["gender"];
      this.hireDate = _data["hireDate"];
      this.salariedFlag = _data["salariedFlag"];
      this.vacationHours = _data["vacationHours"];
      this.sickLeaveHours = _data["sickLeaveHours"];
      this.currentFlag = _data["currentFlag"];
    }
  }

  static fromJS(data: any): EmployeeDto {
    data = typeof data === 'object' ? data : {};
    let result: EmployeeDto = new EmployeeDto();
    result.init(data);
    return result;
  }

  toJSON(data?: any) {
    data = typeof data === 'object' ? data : {};
    data["id"] = this.id;
    data["nationalIdnumber"] = this.nationalIdnumber;
    data["organizationLevel"] = this.organizationLevel;
    data["jobTitle"] = this.jobTitle;
    data["birthDate"] = this.birthDate;
    data["maritalStatus"] = this.maritalStatus;
    data["gender"] = this.gender;
    data["hireDate"] = this.hireDate;
    data["salariedFlag"] = this.salariedFlag;
    data["vacationHours"] = this.vacationHours;
    data["sickLeaveHours"] = this.sickLeaveHours;
    data["currentFlag"] = this.currentFlag;
    return data;
  }


}

export interface IPaginatedListOfEmployeeDto {
  items?: EmployeeDto[] | undefined;
  pageIndex?: number;
  pageSize?: number;
  totalCount?: number;
  totalPages: number;
  hasPreviousPage?: boolean;
  hasNextPage?: boolean;
}

export class PaginatedListOfEmployeeDto implements IPaginatedListOfEmployeeDto {
  items?: EmployeeDto[];
  pageIndex?: number;
  pageSize?: number;
  totalCount?: number;
  totalPages: number;
  hasPreviousPage?: boolean;
  hasNextPage?: boolean;
  constructor(data?: IPaginatedListOfEmployeeDto) {
    if (data) {
      for (let property in data) {
        if (data.hasOwnProperty(property)) {
          (<any>this)[property] = (<any>data)[property];
        }
      }
    }
  }

  init(_data?: any) {
    if(_data){
      if(Array.isArray(_data["items"])){
        this.items = [] as any;
        for (let item of _data["item"]){
          this.items!.push(EmployeeDto.fromJS(item));
        }
      }
      this.pageIndex = _data["pageIndex"];
      this.pageSize = _data["pageSize"];
      this.totalCount = _data["totalCount"];
      this.totalPages = _data["totalPages"];
      this.hasPreviousPage = _data["hasPreviousPage"];
      this.hasNextPage = _data["hasNextPage"];
    }
  }

  static fromJS(data: any): PaginatedListOfEmployeeDto {
    data = typeof data === 'object' ? data : {};
    let result: PaginatedListOfEmployeeDto = new PaginatedListOfEmployeeDto();
    result.init(data);
    return result;
  }

  toJSON(data?: any) {
    data = typeof data === 'object' ? data : {};
    if (Array.isArray(this.items)) {
      data["items"] = [];
      for (let item of this.items) {
        data["items"].push(item.toJSON());
      }
    }
    data["pageIndex"] = this.pageIndex;
    data["pageSize"] = this.pageSize;
    data["totalCount"] = this.totalCount;
    data["totalPages"] = this.totalPages;
    data["hasPreviousPage"] = this.hasPreviousPage;
    data["hasNextPage"] = this.hasNextPage;
    return data;
  }
}


export interface IEmployeesClient {
  getEmployeesWithPagniation(pageIndex: number | undefined, pageSize: number | undefined): Observable<PaginatedListOfEmployeeDto>
}

export interface ICreateEmployeeCommand {
  businessEntityId?: number;
  
}


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
    pageSize: number): Observable<PagedList> {
    let url = this.baseUrl + 'api/v1/employees';
    let params = new HttpParams()
      .set("pageIndex", pageIndex.toString())
      .set("pageSize", pageSize.toString());
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
