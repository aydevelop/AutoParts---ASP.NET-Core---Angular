import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';
import { SharedModule } from '../shared/shared.module';
import { AuthModule } from '../auth/auth.module';

@NgModule({
    declarations: [NavBarComponent],
    imports: [CommonModule, SharedModule, AuthModule],
    exports: [NavBarComponent],
})
export class CoreModule {}
