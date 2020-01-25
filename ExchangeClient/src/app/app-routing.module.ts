import { NgModule } from '@angular/core';
import { Routes, RouterModule, PreloadAllModules } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ExChartComponent } from './chart/chart.component';

const routes: Routes = [
  { path: '', component: HomeComponent},
  { path: 'chart/:id', component: ExChartComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {
    preloadingStrategy: PreloadAllModules}
    )],
  exports: [RouterModule]
})
export class AppRoutingModule { }
