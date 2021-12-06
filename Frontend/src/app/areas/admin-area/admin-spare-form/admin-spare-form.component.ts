import { EventEmitter, Output } from '@angular/core';
import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ICategory } from 'src/app/shared/models/category';
import { ISpare } from 'src/app/shared/models/spare';
import { SpareService } from 'src/app/spare/spare.service';

@Component({
    selector: 'app-admin-spare-form',
    templateUrl: './admin-spare-form.component.html',
    styleUrls: ['./admin-spare-form.component.scss'],
})
export class AdminSpareFormComponent implements OnInit {
    form!: FormGroup;
    @Input()
    model!: ISpare;
    @Output()
    onSaveChanges: EventEmitter<ISpare> = new EventEmitter<ISpare>();

    categories!: ICategory[];
    selectedCategory!: string;

    constructor(
        private router: Router,
        private formBuilder: FormBuilder,
        private spareService: SpareService
    ) {}

    ngOnInit(): void {
        this.selectedCategory = this.model.category?.id || '';
        this.getCategories();

        this.form = this.formBuilder.group({
            name: [
                '',
                {
                    validators: [Validators.required],
                },
            ],
            price: [
                '',
                {
                    validators: [Validators.required],
                },
            ],
            categoryId: [
                '',
                {
                    validators: [Validators.required],
                },
            ],
            description: [
                '',
                {
                    validators: [Validators.required],
                },
            ],
        });

        if (this.model !== undefined) {
            this.form.patchValue(this.model);
        }
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

    saveChanges() {
        this.onSaveChanges.emit(this.form.value);
    }

    getErrorMessageFieldName() {
        const field = this.form.get('name');
        if (field?.hasError('required')) {
            return 'The name field is required!';
        }

        return '';
    }
}
