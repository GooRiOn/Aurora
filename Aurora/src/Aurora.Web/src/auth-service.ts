export interface IAuthService {
    user: IUser;
    isSessionStored: boolean;
    accessToken: string;
    setUser(userName: string): void;
    setAccessToken(accessToken: string, isSessionStored: boolean): void;
    getAccessToken(): string;
    clearAccessToken(): void
    isUserAdmin(): boolean;
}

export interface IUser {
    userName: string;
    userRoles: any[];
}

export class AuthService implements IAuthService {

    user: IUser;
    accessToken: string;
    isSessionStored: boolean;

    constructor()
    {
        this.accessToken = '';
    }

    setUser(userName: string) : void
    {
        var user: IUser = { userName: userName, userRoles: [] };
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
        this.isSessionStored = isSessionStored;
    }

    getAccessToken(): string
    {
        if (this.isSessionStored)
            return sessionStorage.getItem('accessToken');
        else
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
        return this.user.userRoles.some(r => r === 'Admin');
    }
}