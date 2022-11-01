namespace eClothes.Models
{
    public class Jeans
    {
        public int Id { get; set; }
        public string ImageURL { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public string Size { get; set; }
        public List<Discounts> Discounts { get; set; }
    }
}
