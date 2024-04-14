namespace BulkyWeb.Core.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int DisplayOrder { get; set; } // If we have multiple categories => which category should be displayed first on the page
    }
}
