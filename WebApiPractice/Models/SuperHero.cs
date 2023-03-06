using System.ComponentModel.DataAnnotations;

namespace WebApiPractice.Models
{
    public class SuperHero
    {
        public int Id { get; set; }
        [MaxLength(255)]
        public string Name { get; set; } = String.Empty;
        [MaxLength(255)]
        public string FirstName { get; set; } = String.Empty;
        [MaxLength(255)]
        public string LastName { get; set; } = String.Empty;
        [MaxLength(255)]
        public string Place { get; set; } = String.Empty;
    }
}
