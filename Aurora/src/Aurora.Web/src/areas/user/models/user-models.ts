export class UserLoginDto
{
    userName: string;
    password: string;
    rememberMe: boolean;

    constructor()
    {
        this.rememberMe = true;
    }
}


export class UserRegisterDto extends  UserLoginDto
{
    email: string;
    confirmPassword: string;
}