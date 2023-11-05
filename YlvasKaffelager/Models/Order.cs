using YlvasKaffelager.Models.Interfaces;

namespace YlvasKaffelager.Models
{
    /*Används för att skapa bekräftade beställningar (kvitton).
     * Används  för att lägga in bekräftade beställningar i databasen (listan).
     */
    public class Order : IOrder
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Brand { get; set; }
        public int Amount { get; set; }
        public decimal Total { get; set; }
    }
}