namespace DataAccessLayer.Models.Notebook
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class PhoneEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string PhoneNumber { get; set; }

        public long PersonId { get; set; }

        [ForeignKey("PersonId")]
        public PersonEntity Person { get; set; }
    }
}
