import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SpareListComponent } from './spare-list/spare-list.component';
import { SpareItemComponent } from './spare-item/spare-item.component';
import { SpareDetailsComponent } from './spare-details/spare-details.component';

@NgModule({
  declarations: [SpareListComponent, SpareItemComponent, SpareDetailsComponent],
  imports: [CommonModule],
  exports: [SpareListComponent, SpareItemComponent, SpareDetailsComponent],
})
export class SpareModule {}
