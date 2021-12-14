import { ICategory } from './category';
import { IModel } from './model';
import { IProvider } from './provider';

export interface ISpare {
    id: number;
    name: string;
    price: number;
    imageUrl: string;
    description: string;
    url: string;
    modelId: string;
    model?: IModel;
    categoryId: string;
    category?: ICategory;
    providerId: string;
    provider?: IProvider;
    viewCount?: number;
}
