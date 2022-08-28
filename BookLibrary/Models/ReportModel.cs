using BookLibrary.Domain.Entities;
using System;

namespace BookLibrary.Models
{
    public class ReportModel
    {
        public object __PrimaryKey { get; set; }

        public DateTime dataReport { get; set; }
        public int rating_book { get; set; }
        public string URLPresentation { get; set; }
        public string URLVideo { get; set; }
        public string Review { get; set; }

        public ReportModel() { }
        public ReportModel(report value)
        {
            __PrimaryKey = value.__PrimaryKey;
            Review = value.Review;
            //name = value.name;
            //author = value.author;
            //sumPages = value.sumPages;
            //tags = JsonConvert.DeserializeObject<string[]>(value.tags);
            //averageRating = value.averageRating;
            //urlCover = value.URLcover;
            //urlDescription = value.URLDescription;
            //user = value.user;
        }
        public static implicit operator report(ReportModel value)
        {
            return new report(value);
        }
    }
}
