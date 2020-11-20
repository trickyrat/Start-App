import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { publishLast } from 'rxjs/operators';
import { CONTENT_URL_PREFIX } from '../documents/document.service';
import { CurrentNodes, NavigationResponse, NavigationViews, VersionInfo } from './navigation.model';

export const navigationPath = CONTENT_URL_PREFIX + 'navigation.json';

@Injectable({
  providedIn: 'root'
})
export class NavigationService {
  navigationViews: Observable<NavigationViews>;
  versionInfo: Observable<VersionInfo>;
  currentNodes: Observable<CurrentNodes>;

  constructor(private http: HttpClient, private location: LocationService) {
    const navigationInfo = this.fetchNavigationInfo();
    this.navigationViews = this.getNavigationViews(navigationInfo);

   }

   private fetchNavigationInfo(): Observable<NavigationResponse> {
    const navigationInfo = this.http.get<NavigationResponse>(navigationPath)
    .pipe(publishLast());
   }
}
