import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';
import { map, tap } from 'rxjs/operators';
import {
    IAuthenticationResponse,
    IUserCredentials,
} from '../shared/models/authresp';

@Injectable({
    providedIn: 'root',
})
export class AuthService {
    baseUrl = environment.apiUrl;
    tokenKey: string = 'token';
    expirationTokenKey: string = 'token-expiration';
    roleField = 'role';

    constructor(private http: HttpClient, private router: Router) {}

    checkEmailExists(email: string) {
        return this.http.get(this.baseUrl + '/auth/emailexists?email=' + email);
    }

    register(values: IUserCredentials) {
        return this.http.post<IAuthenticationResponse>(
            this.baseUrl + '/auth/register',
            values
        );
    }

    login(values: IUserCredentials) {
        return this.http.post<IAuthenticationResponse>(
            this.baseUrl + '/auth/login',
            values
        );
    }

    getFieldFromJWT(field: string): string {
        const token = localStorage.getItem(this.tokenKey);
        if (!token) {
            return '';
        }
        const dataToken = JSON.parse(atob(token.split('.')[1]));
        return dataToken[field];
    }

    logout() {
        localStorage.removeItem(this.tokenKey);
        localStorage.removeItem(this.expirationTokenKey);
        window.location.href = '/';
    }

    getRole(): string {
        return this.getFieldFromJWT(this.roleField) || '-';
    }

    saveToken(authenticationResponse: IAuthenticationResponse) {
        localStorage.setItem(this.tokenKey, authenticationResponse.token);
        localStorage.setItem(
            this.expirationTokenKey,
            authenticationResponse.expiration.toString()
        );
    }

    getToken() {
        return localStorage.getItem(this.tokenKey);
    }

    isAuthenticated(): boolean {
        const token = localStorage.getItem(this.tokenKey);
        if (!token) {
            return false;
        }

        const expiration = localStorage.getItem(this.expirationTokenKey);
        const expirationDate = new Date(expiration!);

        if (expirationDate <= new Date()) {
            this.logout();
            return false;
        }

        return true;
    }
}
