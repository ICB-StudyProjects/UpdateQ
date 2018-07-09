import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable } from 'rxjs';
import { Configuration } from '../app.constants';

import { InfoNode } from './models/info-node.model';

@Injectable()
export class InfoNodesService {
  private actionUrl: string;
  private headers: HttpHeaders = new HttpHeaders();

  constructor(private http: HttpClient, configuration: Configuration) {
    this.actionUrl = `${configuration.Server}api/infonode`;
  }

  private setHeaders() {
    this.headers = new HttpHeaders({
      'Content-Type': 'application/json',
      Accept: 'application/json'
    });

    // TODO: Get token from Auth Server
    // const token = this._securityService.getToken();
    // if (!token) {
    //    const tokenValue = 'Bearer ' + token;
    //    this.headers = this.headers.append('Authorization', tokenValue);
    // }
  }

  public getAll(): Observable<InfoNode[]> {
    this.setHeaders();

    return this.http.get<InfoNode[]>(this.actionUrl, { headers: this.headers });
  }

  public getById(id: number): Observable<InfoNode> {
    this.setHeaders();

    return this.http.get<InfoNode>(this.actionUrl + id, {
      headers: this.headers
    });
  }

  // public Add() {

  // }

  // public Update() {

  // }

  // public Delete() {

  // }
}
