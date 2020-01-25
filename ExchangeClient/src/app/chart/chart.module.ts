import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ExChartComponent } from './chart.component';
import { RouterModule } from '@angular/router';
import { NgApexchartsModule } from 'ng-apexcharts';

@NgModule({
  declarations:
  [
    ExChartComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    NgApexchartsModule
  ],
  exports: [ExChartComponent]
})
export class ChartModule { }
