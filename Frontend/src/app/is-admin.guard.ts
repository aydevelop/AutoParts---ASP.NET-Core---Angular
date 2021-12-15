import { Injectable } from '@angular/core';
import {
    ActivatedRouteSnapshot,
    CanActivate,
    Router,
    RouterStateSnapshot,
    UrlTree,
} from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from './auth/auth.service';

@Injectable({
    providedIn: 'root',
})
export class IsAdminGuard implements CanActivate {
    constructor(private securitySerice: AuthService, private router: Router) {}

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        if (this.securitySerice.getRole() === 'admin') {
            return true;
        }

        this.router.navigate(['login']);
        return false;
    }
}
