import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ISpare } from 'src/app/shared/models/spare';
import { SpareService } from '../spare.service';

@Component({
    selector: 'app-spare-item',
    templateUrl: './spare-item.component.html',
    styleUrls: ['./spare-item.component.scss'],
})
export class SpareItemComponent implements OnInit {
    @Input() spare!: ISpare;

    constructor(
        private activatedRoute: ActivatedRoute,
        private spareService: SpareService
    ) {}

    ngOnInit(): void {}
}
