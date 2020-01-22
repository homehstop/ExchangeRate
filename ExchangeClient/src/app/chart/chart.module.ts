import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ChartComponent } from './chart.component';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations:
  [
    ChartComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
  ],
  exports: [ChartComponent]
})
export class ChartModule { }
