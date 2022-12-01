using eClothes.Models;

namespace eClothes.Data.ViewModels
{
    public class NewClothesCategoryDropdownVM
    {
        public List<ClothesCategory> ClothesCategory { get; set; }

        public NewClothesCategoryDropdownVM()
        {
            ClothesCategory = new List<ClothesCategory>();
        }
    }
}
