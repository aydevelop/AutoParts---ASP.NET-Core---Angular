import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { IFilterParams } from 'src/app/shared/models/filterparams';
import { ISpare } from 'src/app/shared/models/spare';
import { SpareService } from 'src/app/spare/spare.service';

@Component({
    selector: 'app-admin-spare-list',
    templateUrl: './admin-spare-list.component.html',
    styleUrls: ['./admin-spare-list.component.scss'],
})
export class AdminSpareListComponent implements OnInit {
    spares!: ISpare[];
    params: IFilterParams = new IFilterParams();
    totalCount!: number;
    dataSource!: MatTableDataSource<ISpare>;
    @ViewChild(MatPaginator) paginator!: MatPaginator;
    isLoading: boolean = false;

    columnsToDisplay = [
        'name',
        'price',
        'category',
        'brand',
        'model',
        'actions',
    ];

    constructor(private spareService: SpareService) {}

    ngOnInit(): void {
        this.params.pageSize = 100000;
        this.params.isFull = true;
        this.getSpares();
    }

    ngAfterViewInit() {}

    getSpares() {
        this.spareService.getSpares(this.params).subscribe(
            (resp: any) => {
                this.spares = resp.data;
                this.totalCount = resp.count;
                this.params.pageNumber = resp.pageIndex;
                this.params.pageSize = resp.pageSize;
                this.dataSource = new MatTableDataSource<ISpare>(this.spares);
                this.isLoading = true;
                this.dataSource.paginator = this.paginator;
            },
            (error) => {
                console.log(error);
            }
        );
    }

    delete(id: number) {
        this.spareService.delete(id).subscribe(() => {
            this.getSpares();
        });

        return false;
    }
}
