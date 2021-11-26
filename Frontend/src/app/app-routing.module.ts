import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { ClientListComponent } from './areas/client-area/client-list/client-list.component';
import { AdminListComponent } from './areas/admin-area/admin-list/admin-list.component';
import { LoginComponent } from './auth/login/login.component';
import { RegisterComponent } from './auth/register/register.component';
import { HomeComponent } from './home/home/home.component';
import { SpareDetailsComponent } from './spare/spare-details/spare-details.component';

const routes: Routes = [
    { path: '', component: HomeComponent },
    { path: 'login', component: LoginComponent },
    { path: 'register', component: RegisterComponent },
    { path: 'spare/:id', component: SpareDetailsComponent },

    { path: 'admin-area', component: AdminListComponent },
    { path: 'client-area', component: ClientListComponent },

    { path: '**', redirectTo: '' },
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule],
})
export class AppRoutingModule {}
