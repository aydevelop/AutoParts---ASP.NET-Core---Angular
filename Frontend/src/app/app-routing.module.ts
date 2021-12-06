import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { AdminIndexComponent } from './areas/admin-area/admin-index/admin-index.component';
import { AdminSpareEditComponent } from './areas/admin-area/admin-spare-edit/admin-spare-edit.component';
import { AdminSpareListComponent } from './areas/admin-area/admin-spare-list/admin-spare-list.component';
import { ClientListComponent } from './areas/client-area/client-list/client-list.component';
import { LoginComponent } from './auth/login/login.component';
import { RegisterComponent } from './auth/register/register.component';
import { HomeComponent } from './home/home/home.component';
import { SpareDetailsComponent } from './spare/spare-details/spare-details.component';

const routes: Routes = [
    { path: '', component: HomeComponent },
    { path: 'login', component: LoginComponent },
    { path: 'register', component: RegisterComponent },
    { path: 'spare/:id', component: SpareDetailsComponent },

    {
        path: 'admin-area',
        component: AdminIndexComponent,
        children: [
            { path: '', component: AdminSpareListComponent },
            { path: 'edit/:id', component: AdminSpareEditComponent },
        ],
    },

    { path: 'client-area', component: ClientListComponent },
    { path: '**', redirectTo: '' },
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule],
})
export class AppRoutingModule {}
