using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIForBA.Models
{
    [Table("departments", Schema = "public")]
    public class DepartmentModel
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("title")]
        public string Title { get; set; }
    }
}
