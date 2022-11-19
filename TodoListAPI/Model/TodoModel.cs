using System.ComponentModel.DataAnnotations.Schema;

namespace TodoListAPI.Model
{
    public class TodoModel
    {
        public Guid Id { get; set; }
        public string Task { get; set; }
        public bool Completed { get; set; }
        public string Category { get; set; }
        public DateTime Created { get; set; }
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public UserModel User { get; set; }
    }
}
