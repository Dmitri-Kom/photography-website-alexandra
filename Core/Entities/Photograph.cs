namespace Core.Entities
{
    public class Photograph : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Url { get; set; }

        public PhotographLocation PhotographLocation { get; set; }
        public int PhotographLocationId { get; set; }
    }
}