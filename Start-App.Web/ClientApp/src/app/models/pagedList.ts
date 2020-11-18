export interface PagedList<T> {
  data: T[];
  hasPreviousPage: boolean;
  hasNextPage: boolean;
  pageIndex: number;
  pageSize: number;
  totalCount: number;
  totalPages: number;
}