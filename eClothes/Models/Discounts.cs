namespace eClothes.Models
{
    public class Discounts
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Discount { get; set; }

        public List<Clothes_Discounts> Clothes_Discounts { get; set; }
    }
}
