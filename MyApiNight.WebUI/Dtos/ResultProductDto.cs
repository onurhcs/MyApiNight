namespace MyApiNight.WebUI.Dtos
{
    public class ResultProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductImageUrl { get; set; }
        public string ProductDescription { get; set; }
        public int ProductStock { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal DiscountedPrice { get; set; }

        public string WriterName { get; set; }
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }

    }
}
