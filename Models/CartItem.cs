using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MMLTonga.Models
{
    public class CartItem
    {
        [Key]
        public int Id { get; set; }

        // ProductId is used to establish a foreign key relationship to the Product
        public int ProductId { get; set; }

        // Navigation property for accessing the related Product
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        // Quantity of the Product in the cart, must be at least one
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
        public int Quantity { get; set; }

        // Calculated property for the total price of this cart item, not stored in the database
        [NotMapped]
        public decimal TotalPrice => Product.Price * Quantity;
    }

    public class ShoppingCart
    {
        // Collection of CartItems in the shopping cart
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        // Total quantity of all CartItems in the shopping cart, calculated on the fly
        [NotMapped]
        public int TotalQuantity => Items.Sum(item => item.Quantity);

        // Total price of all CartItems in the shopping cart, calculated on the fly
        [NotMapped]
        public decimal TotalPrice => Items.Sum(item => item.TotalPrice);
    }
}