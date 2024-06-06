using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SportInfo_Back.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; } = string.Empty;
        [Required]
        [JsonIgnore]
        public byte[]? PasswordHash { get; set; }
        [Required]
        [JsonIgnore]
        public byte[]? PasswordSalt { get; set; }   
    }
}
