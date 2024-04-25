using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace API.Dtos
{
    public class ProductFilterDto
    {
        public string? Name { get; set; }
        public string? BrandName { get; set; }
        public string? CategoryName { get; set; }
        public int? AudienceId { get; set; }
        public bool? Available { get; set; }
        public bool? CheaperFirst { get; set; }
        public bool? AlphabeticalOrder { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
