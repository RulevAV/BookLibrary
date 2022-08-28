using BookLibrary.Models;
using ICSSoft.STORMNET;
using System;

namespace BookLibrary.Domain.Entities
{

    [View("reportL", new string[] { "dataReport", "rating_book", "URLPresentation", "URLVideo", "Review", 
        "meeting", 
        "book", "book.name", "book.author", "book.averageRating",
        "speaker", "speaker.lastName", "speaker.firstName" })]
    public class report : ICSSoft.STORMNET.DataObject
    {
        public DateTime dataReport { get; set; }
        public int rating_book { get; set; }
        public string URLPresentation { get; set; }
        public string URLVideo { get; set; }
        public string Review { get; set; }

        private BookLibrary.Domain.Entities.meeting fmeeting;

        private BookLibrary.Domain.Entities.book fbook;

        private BookLibrary.Domain.Entities.speaker fspeaker;

        [PropertyStorage(new string[] { "meeting_m0" })]
        [NotNull()]
        public virtual BookLibrary.Domain.Entities.meeting meeting
        {
            get
            {
                BookLibrary.Domain.Entities.meeting result = this.fmeeting;
                return result;
            }
            set
            {
                this.fmeeting = value;
            }
        }

        [PropertyStorage(new string[] { "book_m0" })]
        [NotNull()]
        public virtual BookLibrary.Domain.Entities.book book
        {
            get
            {
                BookLibrary.Domain.Entities.book result = this.fbook;
                return result;
            }
            set
            {
                this.fbook = value;
            }
        }

        [PropertyStorage(new string[] { "speaker_m0" })]
        [NotNull()]
        public virtual BookLibrary.Domain.Entities.speaker speaker
        {
            get
            {
                BookLibrary.Domain.Entities.speaker result = this.fspeaker;
                return result;
            }
            set
            {
                this.fspeaker = value;
            }
        }

        public report() { }
        public report(ReportModel value)
        {
            dataReport = value.dataReport;
            rating_book = value.rating_book;
            URLPresentation = value.URLPresentation;
            URLVideo =value.URLVideo;
            Review = value.Review;
            //URLcover = value.urlCover;
            //URLDescription = value.urlDescription;
            //user = value.user;
        }

        public static implicit operator ReportModel(report value)
        {
            return new ReportModel(value);
        }

        //[Agregator()]
        ////[NotNull()]
        //public virtual BookLibrary.Domain.Entities.book book
        //{
        //    get
        //    {
        //        BookLibrary.Domain.Entities.book result = this.fbook;
        //        return result;
        //    }
        //    set
        //    {
        //        this.fbook = value;
        //    }
        //}
        //[Agregator()]
        ////[NotNull()]
        //public virtual BookLibrary.Domain.Entities.speaker speaker
        //{
        //    get
        //    {
        //        BookLibrary.Domain.Entities.speaker result = this.fspeaker;
        //        return result;
        //    }
        //    set
        //    {
        //        this.fspeaker = value;
        //    }
        //}
        //[Agregator()]
        ////[NotNull()]
        //public virtual BookLibrary.Domain.Entities.meeting meeting
        //{
        //    get
        //    {
        //        BookLibrary.Domain.Entities.meeting result = this.fmeeting;
        //        return result;
        //    }
        //    set
        //    {
        //        this.fmeeting = value;
        //    }
        //}

        public class Views
        {
            /// <summary>
            /// "bookL" view.
            /// </summary>
            public static ICSSoft.STORMNET.View reportL
            {
                get
                {
                    return ICSSoft.STORMNET.Information.GetView("reportL", typeof(BookLibrary.Domain.Entities.report));
                }
            }
        }

    }

    //public class DetailArrayOfReports : ICSSoft.STORMNET.DetailArray
    //{
    //    public DetailArrayOfReports(BookLibrary.Domain.Entities.book fbook) :
    //            base(typeof(report), ((ICSSoft.STORMNET.DataObject)(fbook)))
    //    {
    //    }

    //    public DetailArrayOfReports(BookLibrary.Domain.Entities.speaker fspeaker) :
    //           base(typeof(report), ((ICSSoft.STORMNET.DataObject)(fspeaker)))
    //    {
    //    }

    //    public DetailArrayOfReports(BookLibrary.Domain.Entities.meeting fmeeting) :
    //           base(typeof(report), ((ICSSoft.STORMNET.DataObject)(fmeeting)))
    //    {
    //    }

    //    public BookLibrary.Domain.Entities.report this[int index]
    //    {
    //        get
    //        {
    //            return ((BookLibrary.Domain.Entities.report)(this.ItemByIndex(index)));
    //        }
    //    }

    //    public virtual void Add(BookLibrary.Domain.Entities.report dataobject)
    //    {
    //        this.AddObject(((ICSSoft.STORMNET.DataObject)(dataobject)));
    //    }

    //}
}
