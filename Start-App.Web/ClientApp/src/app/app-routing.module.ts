import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { EmployeeListComponent } from './employee-list/employee-list.component';
import { LoginComponent } from './oauth/login/login.component';
import { ProductComponent } from "./product/product.component";
import { EmployeeAddComponent } from './employee-list/employee-add/employee-add.component';

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'employees', component: EmployeeListComponent },
  { path: 'login', component: LoginComponent },
  { path: 'productList', component: ProductComponent },
  { path: 'employees-add', component: EmployeeAddComponent }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
