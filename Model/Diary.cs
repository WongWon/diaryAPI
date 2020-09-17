using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace diaryAPI.Model
{
    [Table("DIARY")]
    public partial class Diary
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("title")]
        [StringLength(50)]
        public string Title { get; set; }
        [Column("entry")]
        [StringLength(400)]
        public string Entry { get; set; }
    }
}
