import { IPhotograph } from "./photograph.interface";

export interface IPagination {
    pageIndex: number;
    pageSize: number;
    count: number;
    data: IPhotograph[];
}