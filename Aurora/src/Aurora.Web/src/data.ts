export enum ResultStateEnum {
    Succeed = 1,
    Failed = 2
}

export interface IResult {
    state: ResultStateEnum;
    errors: string[];
}

export interface IPagedResult<TContent> {
    content: TContent[];
    totalPages: number;
}