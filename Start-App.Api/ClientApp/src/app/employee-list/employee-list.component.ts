import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Employee } from '../models/employee';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { EmployeeService } from '../services/employee.service';
import { MatSort } from '@angular/material/sort';
import { PagedList } from '../models/pagedList';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css'],
  providers: [EmployeeService]
})
export class EmployeeListComponent
  implements OnInit {
  public displayedColumns: string[] = ['Id', 'NationalIdnumber', 'OrganizationLevel', 'JobTitle', 'BirthDate', 'MaritalStatus', 'Gender', 'HireDate', 'SalariedFlag', 'VacationHours', 'SickLeaveHours', 'CurrentFlag']
  public employees: MatTableDataSource<Employee>;
  defaultPageIndex: number = 1;
  defaultPageSize: number = 10;
  public defaultSortColumn: string = "businessEntityId";
  public defaultSortOrder: string = "asc";
  defaultFilterColumn: string = "businessEntityId";
  filterQuery: string = null;


  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  constructor(private service: EmployeeService) { }

  ngOnInit() {
    this.loadData(null);
  }

  loadData(query: string = null) {
    var pageEvent = new PageEvent();
    pageEvent.pageIndex = this.defaultPageIndex;
    pageEvent.pageSize = this.defaultPageSize;
    if (query) {
      this.filterQuery = query;
    }
    this.getData(pageEvent);
  }

  getData(event: PageEvent) {
    let sortColumn = (this.sort) ? this.sort.active : this.defaultSortColumn;
    let sortOrder = (this.sort) ? this.sort.direction : this.defaultSortOrder;
    let filterColumn = (this.defaultFilterColumn) ? this.defaultFilterColumn : null;
    let filterQuery = (this.filterQuery) ? this.filterQuery : null;
    this.service.getData<PagedList<Employee>>(
      event.pageIndex,
      event.pageSize,
      sortColumn,
      sortOrder,
      filterColumn,
      filterQuery)
      .subscribe(result => {
        this.paginator.length = result.totalCount;
        this.paginator.pageIndex = result.pageIndex;
        this.paginator.pageSize = result.pageSize;
        this.employees = new MatTableDataSource<Employee>(result.data);
      }, error => console.log(error));
  }
}