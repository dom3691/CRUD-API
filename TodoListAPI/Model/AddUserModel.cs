namespace TodoListAPI.Model
{
    public class AddUserModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Created { get; set; }
    }
}
