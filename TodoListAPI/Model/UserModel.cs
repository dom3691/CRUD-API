namespace TodoListAPI.Model
{
    public class UserModel
    {
        internal string Search;

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Created { get; set; }
    }
}
