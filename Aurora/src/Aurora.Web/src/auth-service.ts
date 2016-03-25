export interface IAuthService {
    user: IUser;
    accessToken: string;
    setUser(user: IUser): void;
    setAccessToken(accessToken: string, isSessionStored: boolean): void;
    getAccessToken(): string;
    clearAccessToken(): void
    isUserAdmin(): boolean;
}

export interface IUser {
    userName: string;
    roles: any[];
}

export class AuthService implements IAuthService {

    user: IUser;
    accessToken: string;

    constructor()
    {
        this.accessToken = '';
    }

    setUser(user: IUser) : void
    {
        this.user = user;
    }

    setAccessToken(accessToken: string, isSessionStored: boolean): void
    {
        if (isSessionStored)
        {
            sessionStorage.setItem('accessToken', accessToken);
            localStorage.clear();
        }
        else
        {
            localStorage.setItem('accessToken', accessToken);
            sessionStorage.clear();
        }

        this.accessToken = accessToken;
    }

    getAccessToken(): string
    {
        var accessToken = sessionStorage.getItem('accessToken');

        if (accessToken)
            return accessToken;
        
        return localStorage.getItem('accessToken');
    }

    clearAccessToken(): void
    {
        localStorage.clear();
        sessionStorage.clear();
        document.cookie = '';
        this.setAccessToken('', true);
    }

    isUserAdmin(): boolean
    {
        if (!this.user) return false;
        return this.user.roles.some(r => r === 'Admin');
    }
}