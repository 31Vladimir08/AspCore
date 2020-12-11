namespace DataAccessLayer.Models.Notebook
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class SkypeEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string SkypeLogin { get; set; }

        public long PersonId { get; set; }

        [ForeignKey("PersonId")]
        public PersonEntity Person { get; set; }
    }

    public class SkypeEntityConfig : IEntityTypeConfiguration<SkypeEntity>
    {
        public void Configure(EntityTypeBuilder<SkypeEntity> builder)
        {
            builder.HasIndex(u => u.SkypeLogin).IsUnique();
        }
    }
}
