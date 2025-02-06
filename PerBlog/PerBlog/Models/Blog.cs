﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerBlog.Models
{
    public class Blog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 
        [Required][Display(Name ="Tiêu đề")]
        public string TieuDe { get; set; }
        [Required][Display(Name = "Nội dung")]
        public string NoiDung { get; set; }
        [Display(Name = "Tác giả")]
        public string TacGia { get; set; }
        [Display(Name = "Tên ảnh")]
        public string TenAnh { get; set; }
        [Display(Name = "Thể loại")]
        public int CateId { get; set; }

        public Category Category { get; set; }
    }
}
