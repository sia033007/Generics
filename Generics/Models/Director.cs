using System.ComponentModel.DataAnnotations;

namespace Generics.Models
{
    public class Director
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
