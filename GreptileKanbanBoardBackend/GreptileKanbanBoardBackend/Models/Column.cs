using System.ComponentModel.DataAnnotations;

namespace GreptileKanbanBoardBackend.Models
{
    public class Column
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<Card> Cards { get; set; }
    }
}
