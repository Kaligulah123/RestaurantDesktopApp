using SQLite;

namespace RestaurantDesktopApp.Data
{
    public class OrderItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int OrderId { get; set; }

        //Esto lo relleno con los datos de MenuItem
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        [Ignore]
        public decimal Amount => Price * Quantity; //SQLite Ignorará este dato al crear la tabla

    }


}
