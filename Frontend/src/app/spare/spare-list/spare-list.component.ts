import { Component, OnInit } from '@angular/core';
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
    constructor(private spareService: SpareService) {}

    ngOnInit(): void {
        this.getSpares();
    }

    getSpares() {
        this.spareService.getSpares().subscribe(
            (resp: any) => {
                this.spares = resp.data;
            },
            (error) => {
                console.log(error);
            }
        );
    }
}
