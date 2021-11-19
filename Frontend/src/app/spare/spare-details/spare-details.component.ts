import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ISpare } from 'src/app/shared/models/spare';
import { SpareService } from '../spare.service';

@Component({
    selector: 'app-spare-details',
    templateUrl: './spare-details.component.html',
    styleUrls: ['./spare-details.component.scss'],
})
export class SpareDetailsComponent implements OnInit {
    spare!: ISpare;

    constructor(
        private activatedRoute: ActivatedRoute,
        private spareService: SpareService
    ) {}

    ngOnInit(): void {
        this.activatedRoute.params.subscribe((params) => {
            let id = params.id;

            this.spareService.getSpare(id).subscribe((spare: ISpare) => {
                this.spare = spare;
            });
        });
    }
}
