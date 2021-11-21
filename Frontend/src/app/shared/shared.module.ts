import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TextInputComponent } from './components/text-input/text-input.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { PagerComponent } from './components/pager/pager.component';
import { PaginationModule } from 'ngx-bootstrap/pagination';

@NgModule({
    declarations: [TextInputComponent, PagerComponent],
    imports: [
        PaginationModule.forRoot(),
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        HttpClientModule,
        RouterModule,
    ],
    exports: [
        FormsModule,
        ReactiveFormsModule,
        RouterModule,
        PaginationModule,
        PagerComponent,
    ],
})
export class SharedModule {}
