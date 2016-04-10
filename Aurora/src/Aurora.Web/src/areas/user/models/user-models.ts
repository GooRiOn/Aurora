export class UserLoginModel
{
    userName: string;
    password: string;
    rememberMe: boolean;

    constructor()
    {
        this.rememberMe = true;
    }
}

export class UserRegisterModel extends UserLoginModel
{
    email: string;
    confirmPassword: string;
}

export class UserPasswordResetModel
{
    email: string;
    token: string;
    passord: string;
    confirmPassword: string;
}

export class UserModel {
    id: string;
    userName: string;
    firstName: string;
    lastName: string;
    email: string;
    isLocked: boolean;
}