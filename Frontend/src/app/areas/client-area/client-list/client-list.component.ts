import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/auth/auth.service';
import { ISpare } from 'src/app/shared/models/spare';
import { SpareService } from 'src/app/spare/spare.service';

@Component({
    selector: 'app-client-list',
    templateUrl: './client-list.component.html',
    styleUrls: ['./client-list.component.scss'],
})
export class ClientListComponent implements OnInit {
    site: string = '';
    siteFull: string = '';
    spares!: ISpare[];
    map = new Map();
    arrCategories: string[] = [];

    constructor(
        private authSerice: AuthService,
        private spareService: SpareService
    ) {}

    ngOnInit(): void {
        this.siteFull = this.authSerice.getFieldFromJWT('site');
        this.site = this.siteFull
            .split('.')[0]
            .replace('https://', '')
            .replace('http://', '');

        this.spareService
            .getSpareByProvider(this.site)
            .subscribe((resp: any) => {
                this.spares = resp;
                this.calc();
            });
    }

    calc() {
        for (const el of this.spares) {
            let check = this.map.get(el.category?.name);
            if (check != undefined) {
                let check2 = +check;
                check2++;
                this.map.set(el.category?.name, check2);
                console.log(el.category?.name);
                console.log(check2);
            } else {
                this.map.set(el.category?.name, 1);
                console.log(el.category?.name);
            }
        }

        this.map.forEach((value, key, map) => {
            this.arrCategories.push(key + ' = ' + value);
        });
    }
}
