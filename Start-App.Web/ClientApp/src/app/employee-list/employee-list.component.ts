import { Component, OnInit, ViewChild, Input } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Employee } from '../models/employee';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { EmployeeDto, EmployeeService } from '../services/employee.service';
import { MatSort } from '@angular/material/sort';
import { PagedList } from '../models/pagedList';
import { SelectionModel } from "@angular/cdk/collections";

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css'],
  providers: [EmployeeService]
})
export class EmployeeListComponent
  implements OnInit {
  public displayedColumns: string[] = ['select', 'Id', 'NationalIdnumber', 'OrganizationLevel', 'JobTitle', 'MaritalStatus', 'Gender']
  public employees: MatTableDataSource<Employee>;
  defaultPageIndex: number = 0;
  defaultPageSize: number = 10;
  filterQuery: string = null;
  selection = new SelectionModel<Employee>();


  @Input() employee: Employee;

  @ViewChild(MatPaginator) paginator: MatPaginator;

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

  isAllSelected() {
    const numSelected = this.selection.selected.length;
    const numRows = this.employees.data.length;
    return numSelected === numRows;
  }

  masterToggle() {
    this.isAllSelected() ?
      this.selection.clear() :
      this.employees.data.forEach(row => this.selection.select(row));
  }

  getData(event: PageEvent) {
    let filterQuery = (this.filterQuery) ? this.filterQuery : null;
    this.service.getData<PagedList<Employee>>(
      event.pageIndex,
      event.pageSize,
      filterQuery)
      .subscribe(result => {
        this.paginator.length = result.totalCount;
        this.paginator.pageIndex = result.pageIndex;
        this.paginator.pageSize = result.pageSize;
        this.employees = new MatTableDataSource<Employee>(result.data);
      }, error => console.log(error));
  }

  addEmployee(employee: Employee) {

  }

}