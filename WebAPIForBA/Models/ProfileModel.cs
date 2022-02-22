using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIForBA.Models
{
    [Table("profiles", Schema = "public")]
    public class ProfileModel
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("first_name")]
        public string FirstName { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }

        [Column("account_id")]
        public int AccountId { get; set; }

        [ForeignKey("AccountId")]
        public virtual AccountModel Account { get; set; }

        [Column("department_id")]
        public int DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual DepartmentModel Department { get; set; }
    }
}
