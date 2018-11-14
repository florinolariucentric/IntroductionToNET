using System.ComponentModel.DataAnnotations;

namespace TodoFullApplication.ViewModel
{
    public class TodoViewModel
    {
        [Required]
        public string Description { get; set; }
    }
}
