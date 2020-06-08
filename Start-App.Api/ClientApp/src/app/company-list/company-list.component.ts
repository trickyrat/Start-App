import { Component, OnInit, ViewChild } from '@angular/core';
import { CompanyService } from '../company/company.service';
import { Company } from '../models/company';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';

@Component({
  selector: 'app-company-list',
  templateUrl: './company-list.component.html',
  styleUrls: ['./company-list.component.css']
})
export class CompanyListComponent implements OnInit {
  companies: Company[];
  displayedColumns: string[] = ['Id', 'CompanyName'];
  dataSource = new MatTableDataSource<Company>(this.companies);

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  constructor(private service: CompanyService) {
    this.service.getCompanies().subscribe(result => {
      this.companies = result;
    }, error => { console.log(error); });
  }
  ngOnInit(): void {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }


}
