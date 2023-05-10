namespace SimpleBookAPI.Data.Entities
{
    public class Book
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public string ISBN { get; set; } = "";
        public string DatePublished { get; set; } = "";
        public string Publisher { get; set; } = "";
        public string Author { get; set; } = "";
        public int TotalPages { get; set; } = 0;
        public string Portrait { get; set; } = "";
    }
}
