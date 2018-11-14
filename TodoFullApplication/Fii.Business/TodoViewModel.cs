using System.ComponentModel.DataAnnotations;

namespace Fii.Business
{
    public class TodoViewModel
    {
        [Required]
        public string Description { get; set; }
    }
}
