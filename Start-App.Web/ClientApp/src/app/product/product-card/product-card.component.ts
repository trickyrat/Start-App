import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'product-card',
  templateUrl: './product-card.component.html',
  styleUrls: ['./product-card.component.css']
})
export class ProductCardComponent implements OnInit {
  description: string = "The Shiba Inu is the smallest of the six original and distinct spitz breeds of dog from Japan. A small, agile dog that copes very well with mountainous terrain, the Shiba Inu was originally bred for hunting."
  imgUrl: string = "https://material.angular.io/assets/img/examples/shiba2.jpg";
  title: string = "Shiba Inu";
  subtitle: string = "Dog Breed";
  constructor() { }

  ngOnInit(): void {
  }

}
