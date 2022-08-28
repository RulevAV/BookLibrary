using BookLibrary.Domain.Entities;
using Newtonsoft.Json;
using System.Text.Json;

namespace BookLibrary.Models
{
    public class BookModel
    {
        public object __PrimaryKey { get; set; }
        public string name { get; set; }
        public string author { get; set; }
        public int sumPages { get; set; }
        public string[] tags { get; set; }
        public int averageRating { get; set; }
        public string urlCover { get; set; }
        public string urlDescription { get; set; }
        public user user { get; set; }
        public BookModel() { }
        public BookModel(book value)
        {
            __PrimaryKey = value.__PrimaryKey;
            name = value.name;
            author = value.author;
            sumPages = value.sumPages;
            tags = JsonConvert.DeserializeObject<string[]>(value.tags);
            averageRating = value.averageRating;
            urlCover = value.URLcover;
            urlDescription = value.URLDescription;
            user = value.user;
        }

        public static implicit operator book(BookModel value)
        {
            return new book(value);
        }
    }
}
