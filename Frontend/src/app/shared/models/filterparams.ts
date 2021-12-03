export class IFilterParams {
    pageNumber: number = 1;
    pageSize: number = 8;
    isFull: boolean = false;

    brandId?: string;
    modelId?: string;
    categoryId?: string;
}
