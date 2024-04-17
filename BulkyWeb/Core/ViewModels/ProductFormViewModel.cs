namespace BulkyWeb.Core.ViewModels
{
    public class ProductFormViewModel
    {
        public int Id { get; set; }
        [MaxLength(500)]
        public string Title { get; set; } = null!;
        [MaxLength(500)]
        public string Description { get; set; } = null!;
        public string ISBN { get; set; } = null!;
        [MaxLength(50)]
        public string Author { get; set; } = null!;
        [Display(Name = "List Price")]
        [Range(1, 1000, ErrorMessage = Errors.MaxRange)]
        public double ListPrice { get; set; }
        [Display(Name = "Price for 1 - 50")]
        [Range(1, 1000, ErrorMessage = Errors.MaxRange)]
        public double Price { get; set; }
        [Display(Name = "Price for 50+")]
        [Range(1, 1000, ErrorMessage = Errors.MaxRange)]
        public double Price50 { get; set; }
        [Display(Name = "Price for 100+")]
        [Range(1, 1000, ErrorMessage = Errors.MaxRange)]
        public double Price100 { get; set; }
    }
}
