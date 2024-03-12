namespace Application.Models.Request.User
{
    public class UpdateUserResquest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Cellphone { get; set; }
    }
}
