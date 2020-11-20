import { Component, EventEmitter, OnInit } from '@angular/core';
import { MatSelectChange } from '@angular/material/select';
import { PagedList } from '../models/pagedList';
import { Product } from '../models/product';
import { ProductCategory, ProductSubcategory } from '../models/product';
import { RequestBase } from '../models/request';
import { ProductService } from "../services/product.service";


@Component({
  selector: 'product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
  products: PagedList<Product>;

  pageIndex: number = 1;
  pageSize: number = 10;
  selectedCategoryId: number;
  selectedSubcategoryId: number;
  filterQuery: string;
  categories: ProductCategory[];
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


    // productWasSelected(product: Product): void {
  //   console.log("Product clicked: ", product);
  // }


  ngOnInit() {
    this.productService.getProductCategory().subscribe(
      res => { this.categories = res },
      err => console.log(err));
  }

  onCategoryChanged(source: MatSelectChange) {
    this.productService.getProductSubcategory(source.value).subscribe(
      res => { this.subcategories = res; },
      err => console.log(err)
    );
  }

  onSubcategoryChanged(source: MatSelectChange) { 
    console.log(source.value);
    console.log(this.selectedSubcategoryId);  
    
  }


  getProducts() {
    let filterQuery = (this.filterQuery) ? this.filterQuery : null;
    let subcategoryId = (this.selectedSubcategoryId) ? this.selectedSubcategoryId : null;
    this.productService.getProducts<PagedList<Product>>(
      subcategoryId,
      filterQuery
    ).subscribe(
      res => {
        this.products = res
      },err => console.log(err));
  }
}
