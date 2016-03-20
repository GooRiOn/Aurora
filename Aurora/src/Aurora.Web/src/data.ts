export enum ResultStateEnum {
    Succeed = 1,
    Failed = 2
}

export interface IResult {
    state: ResultStateEnum;
    errors: string[];
}

export interface IContentResult<TContent> extends IResult {
    content: TContent;
}

export interface IPagedResult<TContent> extends IContentResult<TContent> {
    content: TContent;
}