namespace eClothes.Models
{
    public class Clothes_Discounts
    {
        public int ClothId { get; set; }
        public Clothes Clothes { get; set; }

        public int DiscountId { get; set; }
        public Discounts Discounts { get; set; }
    }
}
