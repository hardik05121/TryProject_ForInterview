using System.ComponentModel.DataAnnotations;

namespace TryProject.Model.DTO
{
    public class CategoryCreateDTO
    {
        [Required]
        public string Name { get; set; }

        public Boolean IsActive { get; set; }
    }
}
