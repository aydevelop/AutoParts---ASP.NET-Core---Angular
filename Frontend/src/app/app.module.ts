import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AdminAreaModule } from './areas/admin-area/admin-area.module';
import { ClientAreaModule } from './areas/client-area/client-area.module';
import { AuthModule } from './auth/auth.module';
import { JwtInterceptorService } from './auth/jwt-interceptor.service';
import { CoreModule } from './core/core.module';
import { HomeModule } from './home/home.module';
import { SharedModule } from './shared/shared.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';
import { GoogleChartsModule } from 'angular-google-charts';
@NgModule({
    declarations: [AppComponent],
    imports: [
        GoogleChartsModule,
        BrowserModule,
        AppRoutingModule,
        CoreModule,
        AuthModule,
        HomeModule,
        AdminAreaModule,
        ClientAreaModule,
        BrowserAnimationsModule,
        FormsModule,
    ],
    providers: [
        {
            provide: HTTP_INTERCEPTORS,
            useClass: JwtInterceptorService,
            multi: true,
        },
    ],
    bootstrap: [AppComponent],
})
export class AppModule {}
