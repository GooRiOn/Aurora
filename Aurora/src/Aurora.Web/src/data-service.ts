﻿import Auth = require("auth-service");
import {HttpClient,json} from "aurelia-fetch-client";
import {inject} from 'aurelia-framework';


export interface IDataService
{
    http: HttpClient;
    authService: Auth.AuthService;
    get<TResponse>(url: string, isAccessTokenRequired: boolean) : Promise<TResponse>;
    post<TResponse>(url: string, data: any, isAccessTokenRequired: boolean) : Promise<TResponse>;

}

export class DataService implements IDataService
{
    http: HttpClient;
    authService: Auth.AuthService;

    constructor(http: HttpClient, authService: Auth.AuthService)
    {
        this.authService = authService;
        this.http = http;

        this.http.configure(config =>
        {
            config.withBaseUrl('http://localhost:49849/api/');
        });
    }

    get<TResponse>(url: string, isAccessTokenRequired: boolean) : Promise<TResponse>
    {
        var requestConfig : any = {};

        if (isAccessTokenRequired)
        {
            var accessToken = this.authService.getAccessToken();
            requestConfig.headers = { 'Authorization': `Bearer ${accessToken}` };
        }

        return this.http.fetch(url, requestConfig).then<TResponse>(response => response.json());
    }

    post<TResponse>(url: string, data : any, isAccessTokenRequired: boolean) : Promise<TResponse>
    {
        var requestConfig: any =
        {
            method: 'post',
            body: json(data)
        };

        if (isAccessTokenRequired) {
            var accessToken = this.authService.getAccessToken();
            requestConfig.headers = { 'Authorization': `Bearer ${accessToken}` };
        }

        return this.http.fetch(url, requestConfig).then<TResponse>(response => response.json());
    }
}