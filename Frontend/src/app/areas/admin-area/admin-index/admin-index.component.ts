import { Component, OnInit } from '@angular/core';
import { IBrand } from 'src/app/shared/models/brand';
import { ICategory } from 'src/app/shared/models/category';
import { IFilterParams } from 'src/app/shared/models/filterparams';
import { IModel } from 'src/app/shared/models/model';
import { ISpare } from 'src/app/shared/models/spare';
import { SpareService } from 'src/app/spare/spare.service';

@Component({
    selector: 'app-admin-index',
    templateUrl: './admin-index.component.html',
    styleUrls: ['./admin-index.component.scss'],
})
export class AdminIndexComponent implements OnInit {
    spares!: ISpare[];
    brands!: IBrand[];
    models!: IModel[];
    categories!: ICategory[];
    params: IFilterParams = new IFilterParams();

    constructor(private spareService: SpareService) {}

    ngOnInit(): void {
        this.spareService.getSpareAll().subscribe(
            (resp: any) => {
                this.spares = resp;
            },
            (error) => {
                console.log(error);
            }
        );

        this.spareService.getBrands().subscribe(
            (resp: any) => {
                this.brands = resp;
            },
            (error) => {
                console.log(error);
            }
        );

        this.spareService.getModels().subscribe(
            (resp: any) => {
                this.models = resp;
            },
            (error) => {
                console.log(error);
            }
        );

        this.spareService.getCategories().subscribe(
            (resp: any) => {
                this.categories = resp;
            },
            (error) => {
                console.log(error);
            }
        );
    }
}
