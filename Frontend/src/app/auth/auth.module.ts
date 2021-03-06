import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RegisterComponent } from './register/register.component';
import { SharedModule } from '../shared/shared.module';
import { LoginComponent } from './login/login.component';
import { AuthorizeViewComponent } from './authorize-view/authorize-view.component';

@NgModule({
    declarations: [RegisterComponent, LoginComponent, AuthorizeViewComponent],
    imports: [CommonModule, SharedModule],
    exports: [RegisterComponent, LoginComponent, AuthorizeViewComponent],
})
export class AuthModule {}
