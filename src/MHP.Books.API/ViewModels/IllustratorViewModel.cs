using System;
using System.ComponentModel.DataAnnotations;

namespace MHP.Books.API.ViewModels
{
    public class IllustratorViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public Guid SpecificationId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Name { get; set; }
    }
}
