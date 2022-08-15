using ICSSoft.STORMNET;
using System;

namespace BookLibrary.Entities
{
    [View("bookL", new string[] { "name", "author", "tags", "suauthormPages", "averageRating", "URLcover", "URLDescription" })]
    public class book : ICSSoft.STORMNET.DataObject
    {
        public string name { get; set; }
        public string author { get; set; }
        public int suauthormPages { get; set; }
        public string[] tags { get; set; }
        public int averageRating { get; set; }
        public string URLcover { get; set; }
        public string URLDescription { get; set; }

        private BookLibrary.Entities.DetailArrayOfReports freport;

        private BookLibrary.Entities.user fuser;

        public void SetProperties(book _book)
        {
            this.name = _book.name;
            this.author = _book.author;
            this.suauthormPages = _book.suauthormPages;
            this.tags = _book.tags;
            this.averageRating = _book.averageRating;
            this.URLcover = _book.URLcover;
            this.URLDescription = _book.URLDescription;
        }

        public virtual BookLibrary.Entities.DetailArrayOfReports reports
        {
            get
            {
                if ((this.freport == null))
                {
                    this.freport = new BookLibrary.Entities.DetailArrayOfReports(this);
                }
                BookLibrary.Entities.DetailArrayOfReports result = this.freport;
                return result;
            }
            set
            {
                this.freport = value;
            }
        }


        [Agregator()]
        [NotNull()]
        public virtual BookLibrary.Entities.user user
        {
            get
            {
                BookLibrary.Entities.user result = this.fuser;
                return result;
            }
            set
            {
                this.fuser = value;
            }
        }

        public class Views
        {
            /// <summary>
            /// "bookL" view.
            /// </summary>
            public static ICSSoft.STORMNET.View bookL
            {
                get
                {
                    return ICSSoft.STORMNET.Information.GetView("bookL", typeof(BookLibrary.Entities.book));
                }
            }
        }

     
    }
    public class DetailArrayOfBooks : ICSSoft.STORMNET.DetailArray
    {
        public DetailArrayOfBooks(BookLibrary.Entities.user fuser) :
                base(typeof(book), ((ICSSoft.STORMNET.DataObject)(fuser)))
        {
        }

        public BookLibrary.Entities.book this[int index]
        {
            get
            {
                return ((BookLibrary.Entities.book)(this.ItemByIndex(index)));
            }
        }

        public virtual void Add(BookLibrary.Entities.book dataobject)
        {
            this.AddObject(((ICSSoft.STORMNET.DataObject)(dataobject)));
        }

    }
}
