namespace Aurora.Domain.DomainObjects
{
    public class UserSelfInfoDomainObject
    {
        public string UserName { get; set; }
        public string[] Roles { get; set; }
    }

    public class UserDomainObject : UserSelfInfoDomainObject
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsLocked { get; set; }
    }
}
