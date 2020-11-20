import { Component, OnInit, ViewChild, Input, AfterViewInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Employee } from '../models/employee';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { EmployeeDto, EmployeeService } from '../services/employee.service';
import { MatSort } from '@angular/material/sort';
import { PagedList } from '../models/pagedList';
import { SelectionModel } from "@angular/cdk/collections";
import { merge } from 'rxjs';
import { startWith, switchMap } from 'rxjs/operators';

@Component({
  selector: 'employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css'],
  providers: [EmployeeService]
})
export class EmployeeListComponent implements AfterViewInit {
  public displayedColumns: string[] = ['select', 'Id', 'NationalIdnumber', 'OrganizationLevel', 'JobTitle', 'MaritalStatus', 'Gender']
  public employees: MatTableDataSource<Employee>;
  defaultPageIndex: number = 0;
  defaultPageSize: number = 10;
  defaultSortColumn = "id";
  defaultSortOrder = "asc";
  defaultFilterColumn = "id";
  defaultFilterQuery: string = null;
  selection = new SelectionModel<Employee>(true, []);
  isLoadingResults = true;

  @Input() employee: Employee
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  constructor(private service: EmployeeService) { }

  ngAfterViewInit() {
    this.loadData();
    this.sort.sortChange.subscribe(() => this.paginator.pageIndex = 0);

  }


  loadData(query?: string, order?: string,) {
    var pageEvent = new PageEvent();
    pageEvent.pageIndex = this.defaultPageIndex;
    pageEvent.pageSize = this.defaultPageSize;
    if (query) {
      this.defaultFilterQuery = query;
    }
    this.getData(pageEvent);
  }

  isAllSelected() {
    const numSelected = this.selection.selected.length;
    const numRows = this.employees.data.length;
    return numSelected === numRows;
  }

  /**
  * Select or deselect all rows.
  */
  masterToggle() {
    this.isAllSelected() ?
      this.selection.clear() :
      this.employees.data.forEach(row => this.selection.select(row));
  }

  /**
   * Get data from service
   * @param event 
   */
  getData(event: PageEvent) {
    let filterQuery = (this.defaultFilterQuery) ? this.defaultFilterQuery : null;
    let filterColumn = (this.defaultFilterColumn) ? this.defaultFilterColumn : null;
    let sortColumn = (this.defaultSortColumn) ? this.defaultSortColumn : null;
    let sortOrder = (this.defaultSortOrder) ? this.defaultSortOrder : null;

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