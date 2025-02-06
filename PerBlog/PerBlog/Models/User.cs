using System.ComponentModel.DataAnnotations;
namespace PerBlog.Models
{
    public class User
    {
        [Key]
        [Required, MinLength(2, ErrorMessage ="Độ dài tối thiểu là 2 kí tự")]
        public string UserName { get; set; }
        [Required, DataType(DataType.Password), MinLength(4, ErrorMessage ="Độ dài tối thiểu là 4 kí tự")]
        public string Password { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        public User() { }

        public User(AppUser appUser)
        {
            UserName = appUser.UserName;
            Password = appUser.PasswordHash;
            Email = appUser.Email;
        }
    }
}
