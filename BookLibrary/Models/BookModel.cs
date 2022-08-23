namespace BookLibrary.Models
{
    public class BookModel
    {
        public string name { get; set; }
        public string author { get; set; }
        public int suauthormPages { get; set; }
        public string[] tags { get; set; }
        public int averageRating { get; set; }
        public string URLcover { get; set; }
        public string URLDescription { get; set; }

    }
}
