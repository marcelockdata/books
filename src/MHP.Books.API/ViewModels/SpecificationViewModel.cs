using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MHP.Books.API.ViewModels
{
    public class SpecificationViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public Guid BookId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string OriginallyPublished { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Author { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]      
        public int PageCount { get; set; }

        public IEnumerable<IllustratorViewModel> Illustrator { get; set; }

        public IEnumerable<GenreViewModel> Genre { get; set; }
    }
}
