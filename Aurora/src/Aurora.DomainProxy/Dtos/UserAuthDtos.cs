namespace Aurora.DomainProxy.Dtos
{
    public class UserLoginDto
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }

    public class UserCreateDto : UserLoginDto
    {
        public string Email { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
