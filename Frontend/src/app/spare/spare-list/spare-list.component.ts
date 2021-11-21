import { Component, OnInit } from '@angular/core';
import { IFilterParams } from 'src/app/shared/models/filterparams';
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
    totalCount!: number;

    constructor(private spareService: SpareService) {}

    ngOnInit(): void {
        this.getSpares();
    }

    getSpares() {
        this.spareService.getSpares(this.params).subscribe(
            (resp: any) => {
                this.spares = resp.data;
                this.totalCount = resp.count;
                this.params.pageNumber = resp.pageIndex;
                this.params.pageSize = resp.pageSize;
            },
            (error) => {
                console.log(error);
            }
        );
    }

    onPageChanged(event: any) {
        if (this.params.pageNumber !== event) {
            this.params.pageNumber = event;
            this.getSpares();
        }
    }

    onPageSize(event: any) {
        if (this.params.pageSize !== event) {
            this.params.pageSize = event;
            this.getSpares();
        }
        return false;
    }
}
