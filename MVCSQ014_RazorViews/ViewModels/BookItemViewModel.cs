namespace MVCSQ014_RazorViews.ViewModels
{
    public class BookItemViewModel
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public string ISBN { get; set; } = "";
        public string Author { get; set; } = "";
        public int TotalPages { get; set; } = 0;
        public string Portrait { get; set; } = "";
    }
}
