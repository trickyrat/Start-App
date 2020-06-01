import { Component, OnInit } from '@angular/core';
import { CompanyService } from '../company/company.service';
import { Company } from '../models/company';

@Component({
  selector: 'app-company-list',
  templateUrl: './company-list.component.html',
  styleUrls: ['./company-list.component.css']
})
export class CompanyListComponent {
  companies: Array<Company>;
  constructor(private service: CompanyService) {
    this.service.getCompanies().subscribe(result => {
      this.companies = result;
    }, error => { console.log(error); });
  }


}
