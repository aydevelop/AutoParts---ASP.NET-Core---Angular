import { Component, OnInit } from '@angular/core';
import { IBrand } from 'src/app/shared/models/brand';
import { ICategory } from 'src/app/shared/models/category';
import { IFilterParams } from 'src/app/shared/models/filterparams';
import { IModel } from 'src/app/shared/models/model';
import { IPagination } from 'src/app/shared/models/pagination';
import { ISpare } from 'src/app/shared/models/spare';
import { SpareService } from '../spare.service';

@Component({
    selector: 'app-spare-list',
    templateUrl: './spare-list.component.html',
    styleUrls: ['./spare-list.component.scss'],
})
export class SpareListComponent implements OnInit {
    spares!: ISpare[];
    params: IFilterParams = new IFilterParams();
    totalCount: number = -1;
    categories!: ICategory[];
    brands!: IBrand[];
    models!: IModel[];
    search: string = '';
    isLoading: boolean = false;

    constructor(private spareService: SpareService) {}

    ngOnInit(): void {
        this.getSpares();
        this.getCategories();
        this.getBrands();
        this.getModels();
    }

    getSpares() {
        this.isLoading = true;
        this.spareService.getSpares(this.params).subscribe(
            (resp: any) => {
                this.spares = resp.data;
                this.totalCount = resp.count;
                this.params.pageNumber = resp.pageIndex;
                this.params.pageSize = resp.pageSize;
                this.params.search = this.search;
                this.isLoading = false;
            },
            (error) => {
                console.log(error);
                this.isLoading = false;
            }
        );
    }

    getCategories() {
        this.spareService.getCategories().subscribe(
            (response) => {
                this.categories = response;
            },
            (error) => {
                console.log(error);
            }
        );
    }

    getBrands() {
        this.spareService.getBrands().subscribe(
            (response) => {
                this.brands = response;
            },
            (error) => {
                console.log(error);
            }
        );
    }

    getModels() {
        this.spareService.getModels().subscribe(
            (response) => {
                this.models = response;
            },
            (error) => {
                console.log(error);
            }
        );
    }

    onPageChanged(event: number) {
        if (this.params.pageNumber !== event) {
            this.params.pageNumber = event;
            this.getSpares();
        }
    }

    onPageSize(event: number) {
        if (this.params.pageSize !== event) {
            this.params.pageSize = event;
            this.params.pageNumber = 1;
            this.getSpares();
        }
        return false;
    }

    onChangeCategory(event: EventTarget | null) {
        if (event != null) {
            this.params.categoryId = (<HTMLInputElement>event).value;
            this.params.pageNumber = 1;
            this.getSpares();
        }
    }

    onChangeBrand(event: EventTarget | null) {
        if (event != null) {
            this.params.brandId = (<HTMLInputElement>event).value;
            this.params.pageNumber = 1;
            this.getSpares();
        }
    }

    onChangeModel(event: EventTarget | null) {
        if (event != null) {
            this.params.modelId = (<HTMLInputElement>event).value;
            this.params.pageNumber = 1;
            this.getSpares();
        }
    }

    modelChanged(newObj: any) {
        this.getSpares();
    }
}
