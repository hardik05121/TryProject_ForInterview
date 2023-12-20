using System.ComponentModel.DataAnnotations;

namespace TryProjectWeb.Model.DTO
{
    public class CategoryCreateDTO
    {
        [Required]
        public string Name { get; set; }

        public Boolean IsActive { get; set; }
    }
}
