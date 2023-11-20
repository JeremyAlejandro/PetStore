using PetStore.Enums;

namespace PetStore.Models
{
    public class Pet
    {
        public long id { get; set; }
        public Category? Category { get; set; }
        public string Name { get; set; }
        public List<string> PhotoUrls { get; set; }
        public List<Tags> Tags { get; set; }
        public PetAvailabilityEnum Status { get; set; }
    }
}
