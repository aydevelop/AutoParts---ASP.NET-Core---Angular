import { IBrand } from './brand';

export interface IModel {
    id: number;
    name: string;
    brandId: string;
    brand?: IBrand;
}
