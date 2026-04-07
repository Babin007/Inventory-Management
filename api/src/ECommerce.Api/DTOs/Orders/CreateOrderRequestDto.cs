using System.ComponentModel.DataAnnotations;

namespace ECommerce.Api.DTOs.Orders;

public class CreateOrderRequestDto
{
    [Required]
    public Guid UserId { get; set; }

    [MinLength(1, ErrorMessage = "At least one line item is required.")]
    public List<CreateOrderItemDto> Items { get; set; } = new();

    public class CreateOrderItemDto
    {
        [Required]
        public Guid ProductId { get; set; }

        [Range(1, 10_000)]
        public int Quantity { get; set; }
    }
}