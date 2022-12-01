using eClothes.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eClothes.Models
{
    public class Producer : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        public string FullName { get; set; }
        public string ProfilePictureURL { get; set; }
        public string ProfileBio { get; set; }

        //relationships
        public List<Clothes>? Clothes { get; set; }
    }
}
