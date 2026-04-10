using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace FlightSearchEngine.Models
{
    public class SearchViewModel
    {
        [Required(ErrorMessage = "Source is required")]
        public string Source { get; set; }

        [Required(ErrorMessage = "Destination is required")]
        public string Destination { get; set; }

        [Required]
        [Range(1, 10, ErrorMessage = "Number of persons must be between 1 and 10")]
        public int NumberOfPersons { get; set; }

        [ValidateNever]
        public SelectList SourceList { get; set; }

        [ValidateNever]
        public SelectList DestinationList { get; set; }
    }
}