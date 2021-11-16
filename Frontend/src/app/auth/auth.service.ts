import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';
import { map, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  baseUrl = environment.apiUrl;
  constructor(private http: HttpClient, private router: Router) {}

  checkEmailExists(email: string) {
    return this.http.get(this.baseUrl + '/auth/emailexists?email=' + email);
  }

  register(values: any) {
    return this.http.post(this.baseUrl + '/auth/register', values).pipe(
      tap((user: any) => {
        if (user) {
          localStorage.setItem('token', user.token);
        }
      })
    );
  }

  login(values: any) {
    return this.http.post(this.baseUrl + '/auth/login', values).pipe(
      tap((user: any) => {
        if (user) {
          localStorage.setItem('token', user.token);
        }
      })
    );
  }
}
