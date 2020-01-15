import 'hammerjs';
import { Component, OnInit } from '@angular/core';
import { CurrencyService } from '../services/currency.service';
import { Currency } from '../models/currency.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  constructor(private currencyService: CurrencyService) {
  }

  currency: Currency;

  createCurrency() {
    this.currencyService.get('').subscribe(x => this.currency = x);
  }

  tabChangeEvent() {
    console.log('tab changed');
  }

  ngOnInit() {
    this.createCurrency();
  }
}
