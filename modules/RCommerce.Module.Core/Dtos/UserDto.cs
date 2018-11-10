namespace RCommerce.Module.Core.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsRememberMe { set; get; }
        public string Token { set; get; }
    }
}
