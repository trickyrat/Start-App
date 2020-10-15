import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Product } from "../models/product";


@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  private currentProduct:Product; 

  @Input() productList: Product[];

  @Output() onProductSelected: EventEmitter<Product>;

  constructor() {
    this.onProductSelected = new EventEmitter();
  }

  ngOnInit(): void {
  }

  productWasSelected(product: Product): void {
    console.log("Product cliked:", product);
  }

  cliked(product:Product):void{
    this.currentProduct = product;
    this.onProductSelected.emit(product);
  }

  // isSelected(product:Product):boolean{
  //   if(!product||!this.currentProduct){
  //     return false;
  //   }
  //   return product.sku === this.currentProduct.sku;
  // }

}
