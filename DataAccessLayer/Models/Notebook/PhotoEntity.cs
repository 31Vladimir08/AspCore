namespace DataAccessLayer.Models.Notebook
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class PhotoEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public byte[] Image1 { get; set; }

        public long PersonId { get; set; }

        [ForeignKey("PersonId")]
        public PersonEntity Person { get; set; }
    }
}
