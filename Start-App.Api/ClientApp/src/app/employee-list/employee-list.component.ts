import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Employee } from '../models/employee';
import { MatPaginator } from '@angular/material/paginator';
import { EmployeeService } from '../services/employee.service';
import { MatSort } from '@angular/material/sort';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css'],
  providers: [EmployeeService]
})
export class EmployeeListComponent implements OnInit {
  displayedColumns: string[] = ['BusinessEntityId', 'NationalIdnumber', 'OrganizationLevel', 'JobTitle', 'BirthDate', 'MaritalStatus', 'Gender', 'HireDate', 'SalariedFlag', 'VacationHours', 'SickLeaveHours', 'CurrentFlag']
  dataSource: MatTableDataSource<Employee>;
  employees: Employee[] = [];

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  constructor(private service: EmployeeService) { }

  getEmployees(): void {
    this.service.getEmployees(1, 10)
      .subscribe(result => (this.employees = result));
  }

  ngOnInit() {
    this.getEmployees();
    this.dataSource = new MatTableDataSource<Employee>(this.employees);
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }
}
