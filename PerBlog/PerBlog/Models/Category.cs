using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerBlog.Models
{
    public class Category
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required][Display(Name = "Tên thể loại")] public string TenTheLoai { get; set; }
        public List<Blog> Blogs { get; set; }
    }
}
