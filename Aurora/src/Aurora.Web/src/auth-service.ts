export interface IAuth {
    user: IUser;
    isSessionStored: boolean;
    accessToken: string;
    setAccessToken(accessToken: string, isSessionStored: boolean): void;
    getAccessToken(): string;
    clearAccessToken(): void
    isUserAdmin(): boolean;
}

export interface IUser {
    username: string;
    userRoles: any[];
    isLoggedIn: boolean;
}

export class AuthService implements IAuth {

    user: IUser;

    constructor()
    {
        this.accessToken = '';
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

    isUserAdmin(): boolean {

        if (!this.user || !this.user.isLoggedIn) return false
        return this.user.userRoles.some(r => r === 'Admin')
    }

    accessToken: string;
    isSessionStored: boolean;
}