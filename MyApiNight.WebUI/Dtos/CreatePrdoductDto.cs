namespace MyApiNight.WebUI.Dtos
{
    public class CreatePrdoductDto
    {
        public string ProductName { get; set; }
        public int ProductStock { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal DiscountedPrice { get; set; }

    }
}
