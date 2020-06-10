import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { MatInput } from "@angular/material/input";

@Component({
  selector: 'app-company-form',
  templateUrl: './company-form.component.html',
  styleUrls: ['./company-form.component.css']
})

// 添加company表单组件
export class CompanyFormComponent implements OnInit {
  companyForm = new FormControl('');
  value = 'Clear me';
  constructor() { 

  }

  ngOnInit(): void {
  }

}
