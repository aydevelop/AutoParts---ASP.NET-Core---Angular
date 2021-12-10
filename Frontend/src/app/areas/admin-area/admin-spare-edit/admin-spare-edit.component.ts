import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ISpare } from 'src/app/shared/models/spare';
import { SpareService } from 'src/app/spare/spare.service';
import { Location } from '@angular/common';

@Component({
    selector: 'app-admin-spare-edit',
    templateUrl: './admin-spare-edit.component.html',
    styleUrls: ['./admin-spare-edit.component.scss'],
})
export class AdminSpareEditComponent implements OnInit {
    model!: ISpare;

    constructor(
        private activatedRoute: ActivatedRoute,
        private spareService: SpareService,
        private location: Location
    ) {}

    ngOnInit(): void {
        this.activatedRoute.params.subscribe((params) => {
            let id = params.id;

            this.spareService.getSpare(id).subscribe((spare: ISpare) => {
                this.model = spare;
            });
        });
    }

    saveChanges(editModel: any) {
        let netModel = Object.assign(this.model, {
            ...editModel,
        });

        this.spareService.edit(this.model.id, netModel).subscribe(
            () => {
                this.location.back();
            },
            (error) => alert('Error: ' + error)
        );
    }
}
