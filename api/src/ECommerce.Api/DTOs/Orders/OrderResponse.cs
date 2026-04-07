namespace ECommerce.Api.DTOs.Orders;

public class OrderResponse
{
    public Guid OrderId { get; set; }
    public decimal TotalAmount { get; set; }
    public DateTime OrderDate { get; set; }

    public List<OrderLine> Lines { get; set; } = new();

    public class OrderLine
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; } 
    }
}