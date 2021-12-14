import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ClientListComponent } from './client-list/client-list.component';
import { MaterialModule } from 'src/app/material/material.module';

import { NgApexchartsModule } from 'ng-apexcharts';

@NgModule({
    declarations: [ClientListComponent],
    imports: [CommonModule, MaterialModule, NgApexchartsModule],
})
export class ClientAreaModule {}
