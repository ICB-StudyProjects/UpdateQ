import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable } from 'rxjs';
import { Configuration } from '../app.constants';

import { InfoNode } from './models/infonode';

@Injectable()
export class infoNodesService {
    private actionUrl: string;
    private headers: HttpHeaders = new HttpHeaders();

    constructor(private http: HttpClient,
        configuration: Configuration) {
        this.actionUrl = `${configuration.Server}api/infonode`;
    }

    private setHeaders() {
        this.headers = new HttpHeaders();
        this.headers = this.headers.set('Content-Type', 'application/json');
        this.headers = this.headers.set('Accept', 'application/json');
      //this.headers = this.headers.set('Access-Control-Allow-Credentials', 'true')

        // TODO: Get token from Auth Server
        //const token = this._securityService.getToken();
        //if (!token) {
        //    const tokenValue = 'Bearer ' + token;
        //    this.headers = this.headers.append('Authorization', tokenValue);
        //}
    }

    public getAll(): Observable<InfoNode[]> {
        this.setHeaders();
        console.log('Inside getAll method!')
        return this.http.get<InfoNode[]>(this.actionUrl, { headers: this.headers });
    }

    public getById(id: number): Observable<InfoNode> {
        this.setHeaders();

        return this.http.get<InfoNode>(this.actionUrl + id, { headers: this.headers });
    }

    //public Add() {

    //}

    //public Update() {

    //}

    //public Delete() {

    //}
}
