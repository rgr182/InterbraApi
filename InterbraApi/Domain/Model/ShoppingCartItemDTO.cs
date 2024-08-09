namespace InterbraApi.Domain.Model
{
    public class ShoppingCartItemDTO
    {
        public int QuantityId { get; set; }
        public int ProductId { get; set; }
        public string Bra { get; set; }
        public string panty { get; set; }
        public char Size { get; set; }
        public string Model { get; set; }
        public string AvailableQuantity { get; set; }
    }
}
