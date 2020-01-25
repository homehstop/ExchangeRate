import { Component, OnInit, ViewChild } from '@angular/core';
import { MonthlyService } from '../services/monthly.service';
import { ActivatedRoute } from '@angular/router';
import { Monthly } from '../models/monthly.model';
import * as moment from 'moment';
import {
  ApexAxisChartSeries,
  ApexChart,
  ApexYAxis,
  ApexXAxis,
  ApexTitleSubtitle,
  ApexTooltip,
  ChartComponent
} from 'ng-apexcharts';

export interface ChartOption {
  series: ApexAxisChartSeries;
  chart: ApexChart;
  xaxis: ApexXAxis;
  yaxis: ApexYAxis;
  title: ApexTitleSubtitle;
  tooltip: ApexTooltip;
}

@Component({
  selector: 'app-chart',
  templateUrl: './chart.component.html',
  styleUrls: ['./chart.component.css'],
})
export class ExChartComponent implements OnInit {
  @ViewChild('chart', {static: false}) chart: ChartComponent;
  public chartOptions: Partial<ChartOption>;
  public monthly: Array<Monthly>;
  public currencyId: number;

  constructor(private monthlyService: MonthlyService, private route: ActivatedRoute) {
  }

  private drawChart() {

    // TODO: fix bug with constructor and ngOnInit
    // check debug errors
    const dataSeries = [];

    for (let i = 0; i < this.monthly.length; i++) {
      dataSeries.push({
        x: new Date(this.monthly[i].published),
        y: [this.monthly[i].open, this.monthly[i].high, this.monthly[i].low, this.monthly[i].close]
      });
    }

    console.log(dataSeries);

    this.chartOptions = {
      series: [
        {
          name: 'candle',
          data: dataSeries,
        }
      ],
      chart: {
        height: 350,
        type: 'candlestick'
      },
      title: {
        text: 'Chart - Category X-axis',
        align: 'left'
      },
      tooltip: {
        enabled: true
      },
      xaxis: {
        type: 'category',
        labels: {
          formatter(val) {
            return moment(val).format('MMMM Do YYYY');
          }
        }
      },
      yaxis: {
        tooltip: {
          enabled: true
        }
      }
    };
  }

  ngOnInit() {
    this.route.params.subscribe(params =>  this.currencyId = params.id);
    this.monthlyService.get(this.currencyId).subscribe((data: Array<Monthly>) => {
      this.monthly = data.slice();
      this.drawChart();
    });
  }
}
