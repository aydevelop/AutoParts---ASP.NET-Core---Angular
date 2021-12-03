import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { IBrand } from '../shared/models/brand';
import { ICategory } from '../shared/models/category';
import { IFilterParams } from '../shared/models/filterparams';
import { IModel } from '../shared/models/model';
import { IPagination } from '../shared/models/pagination';
import { ISpare } from '../shared/models/spare';

@Injectable({
    providedIn: 'root',
})
export class SpareService {
    baseUrl = environment.apiUrl;

    constructor(private http: HttpClient, private router: Router) {}

    getSpares(filterParams: IFilterParams) {
        let params = new HttpParams();
        params = params.append('pageIndex', filterParams.pageNumber.toString());
        params = params.append('pageSize', filterParams.pageSize.toString());

        if (filterParams.categoryId) {
            params = params.append('categoryId', filterParams.categoryId);
        }

        if (filterParams.modelId) {
            params = params.append('modelId', filterParams.modelId);
        }

        if (filterParams.brandId) {
            params = params.append('brandId', filterParams.brandId);
        }

        if (filterParams.isFull) {
            params = params.append('isFull', filterParams.isFull);
        }

        return this.http
            .get<IPagination>(this.baseUrl + '/spare/filter', {
                // observe: 'response',
                params,
            })
            .pipe(
                map((response) => {
                    return response;
                    //return response.body;
                })
            );
    }

    getSpare(id: any) {
        return this.http.get<ISpare>(this.baseUrl + '/spare/details/' + id);
    }

    getCategories() {
        return this.http.get<ICategory[]>(this.baseUrl + '/category');
    }

    getBrands() {
        return this.http.get<IBrand[]>(this.baseUrl + '/brand');
    }

    getModels() {
        return this.http.get<IModel[]>(this.baseUrl + '/model');
    }
}
