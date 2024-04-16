﻿namespace BulkyWeb.Core.ViewModels
{
    public class CategoryFormViewModel
    {
        public int Id { get; set; }
        [MaxLength(100, ErrorMessage = Errors.MaxLength)]
        public string Name { get; set; } = null!;
        [Display(Name = "Display order")]
        public int DisplayOrder { get; set; }
    }
}
