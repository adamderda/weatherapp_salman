import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { MonoTypeOperatorFunction, iif, throwError, of } from 'rxjs';
import { retryWhen, concatMap, delay } from 'rxjs/operators';

//@Injectable({
//  providedIn: 'root'
//})
//export class BaseService {

//  constructor() { }
//}

export abstract class BaseService {
  protected defaultRetryAttempts = 10;
  protected defaultRetryTime = 3000;

  constructor(protected http: HttpClient) { }

  protected httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  protected getRetryPipeline<T>(attempts: number, millisecondsDelay: number): MonoTypeOperatorFunction<T> {
    // 400 range errors will cause it to fail, without retry logic
    return retryWhen(errors =>
      errors.pipe(
        concatMap((e, i) =>
          iif(
            () => (e.status >= 400 && e.status < 500) || i > attempts,
            throwError(e),
            of(e).pipe(delay(millisecondsDelay))
          )
        )
      )
    );
  }
}
