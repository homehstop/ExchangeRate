import { Component, OnInit } from '@angular/core';
import { MonthlyService } from '../services/monthly.service';
import { ActivatedRoute } from '@angular/router';
import { Monthly } from '../models/monthly.model';
import { Chart } from 'chart.js';

@Component({
  selector: 'app-chart',
  templateUrl: './chart.component.html',
  styleUrls: ['./chart.component.css'],
})
export class ChartComponent implements OnInit {
  constructor(private monthlyService: MonthlyService, private route: ActivatedRoute) {
    this.route.params.subscribe(params =>  this.currencyId = params.id);
  }

  currencyId: number;

  monthly: Monthly;

  createMonthly() {
    this.monthlyService.get(this.currencyId).subscribe(x => this.monthly = x);
  }

  drawChart() {
    const elem = document.getElementById('myCanvas') as HTMLCanvasElement;
    const ctx = elem.getContext('2d');

    let chart = new Chart(ctx, {
      type: 'line',
      data: {
        labels: ['2019', '2020'],
        datasets: [{label: 'test1', data: [ 100, 40] }]
      },
      options: {
        responsive: false,
        maintainAspectRatio: true,
        scales: {
          yAxes: [{
            ticks: {
              beginAtZero: true
            }}]}}});
  }

  ngOnInit() {
    this.createMonthly();
    this.drawChart();
  }
}
