import { EventEmitter, Output } from '@angular/core';
import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { IBrand } from 'src/app/shared/models/brand';
import { ICategory } from 'src/app/shared/models/category';
import { IModel } from 'src/app/shared/models/model';
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
    selectedBrand!: string;
    selectedModel!: string;
    brands!: IBrand[];
    models!: IModel[];
    isLoaded: boolean = false;

    constructor(
        private router: Router,
        private formBuilder: FormBuilder,
        private spareService: SpareService
    ) {}

    ngAfterViewInit() {
        this.isLoaded = true;
    }

    ngOnInit(): void {
        this.selectedCategory = this.model.category?.id || '';
        this.selectedBrand = this.model.model?.brand?.id || '';
        this.selectedModel = this.model.model?.id || '';
        this.getCategories();
        this.getBrands();
        this.getModels();

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
            brandId: [
                '',
                {
                    validators: [Validators.required],
                },
            ],
            modelId: [
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
        this.spareService.getModelsByBrand(this.selectedBrand).subscribe(
            (response) => {
                this.models = response;
            },
            (error) => {
                console.log(error);
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

    saveChanges() {
        let netModel = Object.assign(this.form.value);

        this.onSaveChanges.emit(netModel);
    }

    getErrorMessageFieldName() {
        const field = this.form.get('name');
        if (field?.hasError('required')) {
            return 'The name field is required!';
        }

        return '';
    }

    doBrand(event: any) {
        this.selectedBrand = event;
        // if (this.isLoaded == true) {
        //     this.selectedModel = '';
        // }
        this.getModels();
    }
}
