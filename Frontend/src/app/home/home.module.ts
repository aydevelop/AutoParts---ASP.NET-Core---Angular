import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { SpareModule } from '../spare/spare.module';

@NgModule({
  declarations: [HomeComponent],
  imports: [CommonModule, SpareModule],
})
export class HomeModule {}
