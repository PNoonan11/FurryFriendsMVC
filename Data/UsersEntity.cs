using System.ComponentModel.DataAnnotations;

namespace FurryFriendsMVC.Data
{
    public class UserEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public PetTypes PetType { get; set; }

        [Required]
        public Breeds BreedId { get; set; }


        public string Bio { get; set; }
        public string Size { get; set; }

        [Required]
        public CityNames CityID { get; set; }


    }


    public enum Breeds
    {
        GoldenRetriever = 0,
        LabradorRetriever = 1,
        FrenchBullDog = 2,
        Beagle = 3,
        GermanShepherd = 4,
        Poodle = 5,
        Bulldog = 6,
        Pomeranian = 7,
        PitbullTerrier = 8,
        Husky = 9,
        Chihuahua = 10,
        Corgi = 11,
        MixedBreed = 12,
        AlaskanMalamute = 13,
        BorderCollie = 14,
        JackRussellTerrier = 15,
        BassetHound = 16,
        SharPei = 17,
        YorkshireTerrier = 18,
        Rottweiler = 19,
        SaintBernard = 20,
        Newfoundland = 21,
        Greyhound = 22,
        CockerSpaniel = 23,
        Daschund = 24,
        Other = 25

    }
    public enum CityNames
    {
        Indianapolis = 0,
        Mooresville = 1,
        Beach_Grove = 2,
        Carmel = 3,
        Greenwood = 4,
        Planefield = 5,
        Noblesville = 6,
        Brownsburg = 7,
        Fishers = 8,
        Speedway = 9,
        Zionsvile = 10
    }
    public enum PetTypes
    {
        Dog = 0,
        Cat = 1,
        Hampster = 2,
        Chicken = 3,
        Lobster = 4,
        Fish = 5,
        Bird = 6,
        Other = 7

    }

}