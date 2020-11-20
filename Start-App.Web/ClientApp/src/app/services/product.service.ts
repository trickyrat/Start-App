import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpParams } from "@angular/common/http";
import { Product, ProductCategory, ProductSubcategory } from '../models/product';
import { Observable } from 'rxjs';
import { PagedList } from '../models/pagedList';


@Injectable({
  providedIn: 'root'
})
export class ProductService {

  apiUrl: string = "api/v1/Products/";

  constructor(private httpClient: HttpClient,
    @Inject('BASE_URL') private baseUrl: string) {

  }

  getProductCategory(): Observable<ProductCategory[]> {
    return this.httpClient.get<Array<ProductCategory>>(this.baseUrl + this.apiUrl + "category");
  }

  getProductSubcategory(categoryId: number): Observable<ProductSubcategory[]> {
    return this.httpClient.get<ProductSubcategory[]>(this.baseUrl + this.apiUrl + "category/" + categoryId)
  }

  // 获取产品
  getProducts<PagedList>(subcategoryId?: number, filterQuery?: string): Observable<PagedList> {
    let params: HttpParams = new HttpParams();
    let url: string = this.baseUrl + this.apiUrl;
    if (subcategoryId) {
      params = params.set("subcategoryId", subcategoryId.toString());
    }
    if (filterQuery) {
      params = params.set("filterQuery", filterQuery);
    }
    return this.httpClient.get<PagedList>(url, { params });
  }

}
