namespace Aurora.Domain.DomainObjects
{
    public class UserLoginDomainObject
    {
        public string UserName { get; set; }
        
        public string Password { get; set; } 

        public bool RememberMe { get; set; }
    }

    public class UserCreateDomainObject : UserLoginDomainObject
    {
        public string Email { get; set; }
    }
}
