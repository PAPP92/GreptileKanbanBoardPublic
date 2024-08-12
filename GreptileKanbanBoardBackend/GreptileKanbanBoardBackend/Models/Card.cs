using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreptileKanbanBoardBackend.Models
{
    public class Card
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        [ForeignKey("Column")]
        public int Column_Id { get; set; }
        public Column Column { get; set; }
    }
}
