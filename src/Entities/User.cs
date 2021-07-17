using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Api.Entities
{
    [DataContract]
    [Table("\"public\".\"User\"")]
    public class User
    {
        [DataMember]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }

        [DataMember]
        [Column("Email")]
        public string Email { get; set; }

        [DataMember]
        [Column("Password")]
        public string Password { get; set; }

        [DataMember]
        [Column("FirstName")]
        public string FirstName { get; set; }

        [DataMember]
        [Column("LastName")]
        public string LastName { get; set; }
    }
}