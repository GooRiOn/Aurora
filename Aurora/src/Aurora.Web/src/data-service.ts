import auth = require("auth-service");
import {HttpClient,json} from "aurelia-fetch-client";
import {inject} from 'aurelia-framework';
 

export interface IDataService
{
    host: string;
    http: HttpClient;
    authService: auth.AuthService;
    get<TResponse>(url: string, isAccessTokenRequired: boolean) : Promise<TResponse>;
    post<TResponse>(url: string, data: any, isAccessTokenRequired: boolean) : Promise<TResponse>;

}

export class DataService implements IDataService
{
    http: HttpClient;
    authService: auth.AuthService;
    host = 'http://localhost:9000/api/';

    constructor(http: HttpClient, authService: auth.AuthService)
    {
        this.authService = authService;
        this.http = http;

        this.http.configure(config =>
        {
            config.withBaseUrl(this.host);
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


