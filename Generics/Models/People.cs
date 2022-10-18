using System.ComponentModel.DataAnnotations;

namespace Generics.Models
{
    public class People
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
