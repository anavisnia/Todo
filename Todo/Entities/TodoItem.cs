using System.ComponentModel.DataAnnotations;

namespace Todo.Entities
{
    public class TodoItem
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }
    }
}
