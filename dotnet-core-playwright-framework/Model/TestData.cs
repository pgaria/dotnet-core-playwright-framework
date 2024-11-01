namespace Tests.Model
{
    public class TestData
    {
        public TestUser TestUser { get; set; }
    }

    public class TestUser
    {
        public UserDetails StandardUser { get; set; }
    }

    public class UserDetails
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string Password { get; set; }
    }
}