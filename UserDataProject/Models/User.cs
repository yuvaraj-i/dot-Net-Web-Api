using System.ComponentModel.DataAnnotations;

namespace UserDataProject.Models
{
    public class User
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;
        [StringLength(50)]
        public string Email { get; set; } = string.Empty;
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [StringLength(20)]
        public string Password { get; set; } = string.Empty;
    }
}
