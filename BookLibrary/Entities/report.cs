using ICSSoft.STORMNET;
using System;

namespace BookLibrary.Entities
{

    [View("reportL", new string[] { "dataReport", "rating_book", "URLPresentation", "URLVideo", "Review" })]
    public class report : ICSSoft.STORMNET.DataObject
    {
        public DateTime dataReport { get; set; }
        public int rating_book { get; set; }
        public string URLPresentation { get; set; }
        public string URLVideo { get; set; }
        public string Review { get; set; }

        private BookLibrary.Entities.book fbook;

        private BookLibrary.Entities.speaker fspeaker;

        private BookLibrary.Entities.meeting fmeeting;
        public void SetProperties(report _report)
        {
            this.dataReport = _report.dataReport;
            this.rating_book = _report.rating_book;
            this.URLPresentation = _report.URLPresentation;
            this.URLVideo = _report.URLVideo;
            this.Review = _report.Review;
        }

        [Agregator()]
        //[NotNull()]
        public virtual BookLibrary.Entities.book book
        {
            get
            {
                BookLibrary.Entities.book result = this.fbook;
                return result;
            }
            set
            {
                this.fbook = value;
            }
        }
        [Agregator()]
        //[NotNull()]
        public virtual BookLibrary.Entities.speaker speaker
        {
            get
            {
                BookLibrary.Entities.speaker result = this.fspeaker;
                return result;
            }
            set
            {
                this.fspeaker = value;
            }
        }
        [Agregator()]
        //[NotNull()]
        public virtual BookLibrary.Entities.meeting meeting
        {
            get
            {
                BookLibrary.Entities.meeting result = this.fmeeting;
                return result;
            }
            set
            {
                this.fmeeting = value;
            }
        }

        public class Views
        {
            /// <summary>
            /// "bookL" view.
            /// </summary>
            public static ICSSoft.STORMNET.View reportL
            {
                get
                {
                    return ICSSoft.STORMNET.Information.GetView("reportL", typeof(BookLibrary.Entities.report));
                }
            }
        }

    }

    public class DetailArrayOfReports : ICSSoft.STORMNET.DetailArray
    {
        public DetailArrayOfReports(BookLibrary.Entities.book fbook) :
                base(typeof(report), ((ICSSoft.STORMNET.DataObject)(fbook)))
        {
        }

        public DetailArrayOfReports(BookLibrary.Entities.speaker fspeaker) :
               base(typeof(report), ((ICSSoft.STORMNET.DataObject)(fspeaker)))
        {
        }

        public DetailArrayOfReports(BookLibrary.Entities.meeting fmeeting) :
               base(typeof(report), ((ICSSoft.STORMNET.DataObject)(fmeeting)))
        {
        }

        public BookLibrary.Entities.report this[int index]
        {
            get
            {
                return ((BookLibrary.Entities.report)(this.ItemByIndex(index)));
            }
        }

        public virtual void Add(BookLibrary.Entities.report dataobject)
        {
            this.AddObject(((ICSSoft.STORMNET.DataObject)(dataobject)));
        }

    }
}
