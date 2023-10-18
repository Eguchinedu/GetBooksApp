using System.ComponentModel.DataAnnotations;

namespace GetBooksApp.Dtos
{
    public class BookForCreationDto
    {
        [Required(ErrorMessage ="Book Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Book Author is required")]
        public string Author { get; set; }
    }
}
