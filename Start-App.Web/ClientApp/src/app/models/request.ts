export class RequestBase {

    constructor(public pageIndex: number,
        public pageSize: number,
        public sortColumn: string,
        public sortOrder: string,
        public filterColumn: string,
        public filterQuery: string) { }
}      