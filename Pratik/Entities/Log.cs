using Pratik.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pratik
{
    [Table("log")]
    public class Log
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Column("date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Date { get; set; }
        
        [Column("http_date")]
        public HttpMethodEnum HttpMethod { get; set; }
        
        [Column("path")]
        public string Path { get; set; }
        
        [Column("log_type")]
        public LogType LogType { get; set; }

    }
}
