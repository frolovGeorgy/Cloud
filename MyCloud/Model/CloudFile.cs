 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCloud.Model
{
    [Table("file", Schema = "public")]
    public class CloudFile
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FileId { get; set; }

        [Required]
        [Column("content")]
        public byte[] Content { get; set; }

        [MaxLength(200)]
        [Required]
        [Column("file_name")]
        public string FileName { get; set; }

        [Required]
        [Column("file_size")]
        public float FileSize { get; set; }
    }
}
