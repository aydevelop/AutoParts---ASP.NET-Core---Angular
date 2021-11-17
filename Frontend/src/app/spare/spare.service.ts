import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class SpareService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient, private router: Router) {}

  getSpares() {
    return this.http
      .get(this.baseUrl + '/spare', {
        observe: 'response',
      })
      .pipe(
        map((response) => {
          return response.body;
        })
      );
  }

  getSpare(id: any) {
    return this.http.get(this.baseUrl + '/spare/' + id);
  }
}
