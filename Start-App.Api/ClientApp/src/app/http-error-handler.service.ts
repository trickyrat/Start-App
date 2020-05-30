import { Injectable } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { Observable, from, of } from 'rxjs';
import { MessageService } from './message.service';
import { ERROR_COMPONENT_TYPE } from '@angular/compiler';


export type HandleError = <T>(operation?: string, result?: T) => (error: HttpErrorResponse) => Observable<T>;

@Injectable({
  providedIn: 'root'
})
export class HttpErrorHandler {

  constructor(private messageService: MessageService) {

  }

  createHandleError = (serviceName = '') => <T>
    (operation = 'operation', result = {} as T) => this.handleError(serviceName, operation, result);

  handleError<T>(serviceName = '', operation = 'operation', result = {} as T) {
    return (error: HttpErrorResponse): Observable<T> => {
      // TODO:send the error message to remote logging infrastructure
      console.error(error);

      const message = (error.error instanceof ErrorEvent) ?
        error.error.message :
        `server returned code ${error.status} with  body "${error.error}"`;

      // TODO: send error message to user
      this.messageService.add(`${serviceName}: ${operation} failed: ${message}`);

      return of(result);
    };
  }


}
