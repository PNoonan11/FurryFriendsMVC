using System.ComponentModel.DataAnnotations;

namespace FurryFriendsMVC.Models.User
{
    public class UserDetail
    {
        public int Id { get; set; }
        [Display(Name = "Pet's Name")]
        public string Name { get; set; }
        [Display(Name = "Pet's Age")]
        public int Age { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Display(Name = "Pet Type")]
        public PetTypes PetType { get; set; }

        [Required]
        public Breeds BreedId { get; set; }


        public string Bio { get; set; }
        [Display(Name = "Pet Size")]
        public string Size { get; set; }

        [Required]
        [Display(Name = "Location")]
        public CityNames CityID { get; set; }
    }



}