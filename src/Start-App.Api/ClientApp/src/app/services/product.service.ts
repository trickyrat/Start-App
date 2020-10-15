import { Inject, Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Product, ProductCategory, ProductSubcategory } from '../models/product';
import { Observable } from 'rxjs';
import { RequestBase } from '../models/request';


@Injectable({
  providedIn: 'root'
})
export class ProductService {

  apiUrl: string = "api/v1/Products/";

  constructor(private httpClient: HttpClient,
    @Inject('BASE_URL') private baseUrl: string) {

  }

  getProductCategory(): Observable<ProductCategory[]> {
    return this.httpClient.get<Array<ProductCategory>>(this.baseUrl + this.apiUrl + "productcategory");
  }

  getProductSubcategory(categoryId: number): Observable<ProductSubcategory[]> {
    return this.httpClient.get<ProductSubcategory[]>(this.baseUrl + this.apiUrl + "productsubcategory?subCategoryId=" + categoryId)
  }

  // 获取产品
  getProducts(rquest: RequestBase): Observable<Product[]> {
    return this.httpClient.get<Product[]>(this.baseUrl + this.apiUrl);
  }

}
