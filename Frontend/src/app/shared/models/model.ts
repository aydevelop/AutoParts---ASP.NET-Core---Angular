import { IBrand } from './brand';

export interface IModel {
    id: string;
    name: string;
    brandId: string;
    brand?: IBrand;
}
