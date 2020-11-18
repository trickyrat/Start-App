import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PagedList } from '../models/pagedList';

export abstract class BaseService {
  constructor(protected http: HttpClient, protected baseUrl: string) { }

  abstract getData<PagedList>(
    pageIndex: number,
    pageSize: number,
    searchQuery: string
  ): Observable<PagedList>;

  abstract get<T>(id: number): Observable<T>;

  abstract put<T>(item: T): Observable<T>;

  abstract post<T>(item: T): Observable<T>;
}

