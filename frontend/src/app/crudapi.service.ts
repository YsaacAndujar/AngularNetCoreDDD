import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class CrudapiService<TEntity, TentityId> {
  url:string = 'https://localhost:8001/api/'
  public setBase(base: string):void{
    this.url= `https://localhost:8001/api/${base}/`
  }
  constructor(private http: HttpClient) { }

  public getAll(): Observable<TEntity[]> {
    return this.http.get<TEntity[]>(this.url);
  }

  public findById(id: TentityId): Observable<TEntity> {
    return this.http.get<TEntity>(this.url+id);
  }

  public create(data: TEntity): Observable<TEntity> {
    return this.http.post<TEntity>(this.url, data);
  }

  public update(data: TEntity): Observable<TEntity> {
    return this.http.put<TEntity>(this.url, data);
  }

  public delete(id: TentityId): Observable<TEntity> {
    return this.http.delete<TEntity>(this.url+id);
  }
}
