import {
    HttpHandler,
    HttpInterceptor,
    HttpRequest,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuthService } from './auth.service';

@Injectable({
    providedIn: 'root',
})
export class JwtInterceptorService implements HttpInterceptor {
    constructor(private authService: AuthService) {}

    intercept(req: HttpRequest<any>, next: HttpHandler): any {
        const token = this.authService.getToken();

        if (token) {
            req = req.clone({
                setHeaders: { Authorization: `Bearer ${token}` },
            });
        }

        return next.handle(req);
    }
}
