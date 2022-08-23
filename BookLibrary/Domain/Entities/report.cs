using ICSSoft.STORMNET;
using System;

namespace BookLibrary.Domain.Entities
{

    [View("reportL", new string[] { "dataReport", "rating_book", "URLPresentation", "URLVideo", "Review" })]
    public class report : ICSSoft.STORMNET.DataObject
    {
        public DateTime dataReport { get; set; }
        public int rating_book { get; set; }
        public string URLPresentation { get; set; }
        public string URLVideo { get; set; }
        public string Review { get; set; }

        private BookLibrary.Domain.Entities.book fbook;

        private BookLibrary.Domain.Entities.speaker fspeaker;

        private BookLibrary.Domain.Entities.meeting fmeeting;
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
        [Agregator()]
        //[NotNull()]
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
        [Agregator()]
        //[NotNull()]
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

    public class DetailArrayOfReports : ICSSoft.STORMNET.DetailArray
    {
        public DetailArrayOfReports(BookLibrary.Domain.Entities.book fbook) :
                base(typeof(report), ((ICSSoft.STORMNET.DataObject)(fbook)))
        {
        }

        public DetailArrayOfReports(BookLibrary.Domain.Entities.speaker fspeaker) :
               base(typeof(report), ((ICSSoft.STORMNET.DataObject)(fspeaker)))
        {
        }

        public DetailArrayOfReports(BookLibrary.Domain.Entities.meeting fmeeting) :
               base(typeof(report), ((ICSSoft.STORMNET.DataObject)(fmeeting)))
        {
        }

        public BookLibrary.Domain.Entities.report this[int index]
        {
            get
            {
                return ((BookLibrary.Domain.Entities.report)(this.ItemByIndex(index)));
            }
        }

        public virtual void Add(BookLibrary.Domain.Entities.report dataobject)
        {
            this.AddObject(((ICSSoft.STORMNET.DataObject)(dataobject)));
        }

    }
}
