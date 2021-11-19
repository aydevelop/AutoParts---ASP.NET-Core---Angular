import { ISpare } from './spare';

export interface IPagination {
    id: number;
    pageIndex: number;
    pageSize: number;
    count: number;
    data: ISpare[];
}
