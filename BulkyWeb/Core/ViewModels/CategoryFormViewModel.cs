﻿namespace BulkyWeb.Core.ViewModels
{
    public class CategoryFormViewModel
    {
        public int Id { get; set; }
        [MaxLength(100, ErrorMessage = Errors.MaxLength)]
        [Remote("AllowItem", null!, AdditionalFields = "Id", ErrorMessage = Errors.Duplicated)]
        public string Name { get; set; } = null!;
        [Range(1, 100, ErrorMessage = Errors.MaxRange)]
        [Display(Name = "Display order")]
        public int DisplayOrder { get; set; }
    }
}
