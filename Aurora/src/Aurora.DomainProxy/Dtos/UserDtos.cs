namespace Aurora.DomainProxy.Dtos
{
    public class UserSelfInfoDto
    {
        public string UserName { get; set; }
        public string[] Roles { get; set; }
    }

    public class UserDto : UserSelfInfoDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsLocked { get; set; }
    }
}
