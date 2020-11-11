import { Component, EventEmitter, OnInit } from '@angular/core';
import { MatSelectChange } from '@angular/material/select';
import { Product } from '../models/product';
import { ProductCategory, ProductSubcategory } from '../models/product';
import { RequestBase } from '../models/request';
import { ProductService } from "../services/product.service";


@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
  products: Product[];

  pageIndex: number = 1;
  pageSize: number = 10;

  // 已选中分类
  selectedCategoryId: number;
  // 已选中子分类
  selectedSubcategoryId: number;

  // 产品分类数组
  categories: ProductCategory[];
  // 产品子分类数组
  subcategories: ProductSubcategory[];

  constructor(private productService: ProductService) {
    // this.products = [
    //   new Product(
    //     'MYSHOES',
    //     'Black Running Shoes',
    //     '/assets/images/products/black-shoes.jpg',
    //     ['Men', 'Shoes', 'Running Shoes'],
    //     109.99),
    //   new Product(
    //     'NEATOJACKET',
    //     'Blue Jacket',
    //     '/assets/images/products/blue-jacket.jpg',
    //     ['Women', 'Apparel', 'Jackets & Vests'],
    //     238.99),
    //   new Product(
    //     'NICEHAT',
    //     'A Nice Black Hat',
    //     '/assets/images/products/black-hat.jpg',
    //     ['Men', 'Accessories', 'Hats'],
    //     29.99)
    // ];
  }

  ngOnInit(): void {
    this.productService.getProductCategory().subscribe(
      res => { this.categories = res },
      err => console.log(err));
  }

  // productWasSelected(product: Product): void {
  //   console.log("Product clicked: ", product);
  // }

  onCategoryChanged(source: MatSelectChange): void {
    this.productService.getProductSubcategory(source.value).subscribe(
      res => { this.subcategories = res; },
      err => console.log(err)
    );
  }

  onSubcategoryChanged(source: MatSelectChange): void { 
    console.log(source.value);
    console.log(this.selectedSubcategoryId);
  }

  getProducts(): void {
    let request: RequestBase = new RequestBase(this.pageIndex, this.pageSize, "", "ASC", "", "");
    this.productService.getProducts(request).subscribe(res => {this.products = res},err => console.log(err));
  }
}
