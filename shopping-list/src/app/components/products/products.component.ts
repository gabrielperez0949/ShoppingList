import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Product } from 'src/app/models/product';
import { PRODUCTS, ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {

  @Input() products : Product[] = [];

  @Output() addShoppingCartItem = new EventEmitter<string>();

  constructor() {}

  ngOnInit(): void { }
}
