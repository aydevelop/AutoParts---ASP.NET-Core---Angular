import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminIndexComponent } from './admin-index/admin-index.component';
import { AdminSpareListComponent } from './admin-spare-list/admin-spare-list.component';
import { AdminSpareEditComponent } from './admin-spare-edit/admin-spare-edit.component';
import { AdminSpareCreateComponent } from './admin-spare-create/admin-spare-create.component';
import { AdminSpareFormComponent } from './admin-spare-form/admin-spare-form.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { MaterialModule } from 'src/app/material/material.module';

@NgModule({
    declarations: [
        AdminIndexComponent,
        AdminSpareListComponent,
        AdminSpareEditComponent,
        AdminSpareCreateComponent,
        AdminSpareFormComponent,
    ],
    imports: [CommonModule, SharedModule, MaterialModule],
})
export class AdminAreaModule {}
