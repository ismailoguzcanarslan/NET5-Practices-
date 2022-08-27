using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pratik.Entities
{
    [Table("book")]
    public class Book
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("title")]
        [StringLength(50)]
        public string Title { get; set; }
        
        [Column("genreid")]
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        
        [Column("page_count")]
        public int PageCount { get; set; }
        
        [Column("publish_date")]
        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }
    }
}
