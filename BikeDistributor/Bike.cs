namespace BikeDistributor
{
    public class Bike
    {


        public Bike(string brand, string model, int price)
        {
            Brand = brand;
            Model = model;
            Price = price;
        }

        public string Brand { get; set; }
        public string Model { get; set; }
        public int Price { get; set; }
    }
}
