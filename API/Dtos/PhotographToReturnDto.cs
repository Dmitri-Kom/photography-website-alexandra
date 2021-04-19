namespace API.Dtos
{
    public class PhotographToReturnDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Url { get; set; }

        public string PhotographLocation { get; set; }
    }
}