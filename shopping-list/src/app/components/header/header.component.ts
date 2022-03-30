import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  @Input() title = 'Shopping List Application';

  @Input() shoppingListCount: number;

  @Output() toggleShoppingList = new EventEmitter();

  constructor() { }

  ngOnInit(): void {
  }

}
