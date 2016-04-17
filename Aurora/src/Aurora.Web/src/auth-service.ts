export interface IAuthService {
    user: IUser;
    setUser(user: IUser): void;
    setAccessToken(accessToken: string, isSessionStored: boolean): void;
    getAccessToken(): string;
    clearAccessToken(): void;
    isUserAdmin(): boolean;
    isUserLogged(): boolean;
    getUserDefaultProject(): IUserProject;
}

export interface IUserProject
{
    id: number;
    name: string;
    isDefault: boolean;
}

export interface IUser {
    userName: string;
    roles: any[];
    projects: IUserProject[];
}

export class AuthService implements IAuthService {

    user: IUser;
    private accessToken: string;
    private isSessionStored : boolean;

    constructor()
    {
        this.accessToken = '';
        this.isSessionStored = true;
    }

    setUser(user: IUser) : void
    {
        this.user = user;
    }

    setAccessToken(accessToken: string, isSessionStored: boolean): void
    {
        if (isSessionStored)
        {
            localStorage.setItem('accessToken', accessToken);
            sessionStorage.clear();
        }
        else
        {
            sessionStorage.setItem('accessToken', accessToken);
            localStorage.clear();
        }

        this.accessToken = accessToken;
        this.isSessionStored = isSessionStored;
    }

    getAccessToken(): string
    {
        return this.isSessionStored? localStorage.getItem('accessToken') : sessionStorage.getItem('accessToken');
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

    isUserLogged(): boolean
    {
        return this.user ? true : false;
    }

    getUserDefaultProject(): IUserProject
    {
        return this.user.projects.firstOrNull(p => p.isDefault);
    }
}