namespace Aurora.Infrastructure.Models.ReadModels
{
    public class UserLoginInfoReadModel
    {
        public string Id { get; set; }

        public bool IsLocked { get; set; }

        public bool IsActive { get; set; }

        public string[] Roles { get; set; }
    }

    public class UserSelfInfoReadModel
    {
        public string UserName { get; set; }
        public string[] Roles { get; set; }
    }

    public class UserReadModel : UserSelfInfoReadModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsLocked { get; set; }
    }
}
