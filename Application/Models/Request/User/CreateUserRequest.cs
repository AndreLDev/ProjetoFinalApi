namespace Application.Models.Request.User
{
    public class CreateUserRequest
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
        public string Cellphone { get; set; }
    }
}
