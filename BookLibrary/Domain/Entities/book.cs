using BookLibrary.Models;
using ICSSoft.STORMNET;
using Newtonsoft.Json;
using System;
using System.Text.Json;

namespace BookLibrary.Domain.Entities
{
    [View("bookL", new string[] { "name", "author", "sumPages", "tags","averageRating", "URLcover", "URLDescription", "user", "user.email" })]
    public class book : ICSSoft.STORMNET.DataObject
    {
        public string name { get; set; }
        public string author { get; set; }
        public int sumPages { get; set; }
        public string tags { get; set; }
        public int averageRating { get; set; }
        public string URLcover { get; set; }
        public string URLDescription { get; set; }

        //private BookLibrary.Domain.Entities.DetailArrayOfReports freport;

        private BookLibrary.Domain.Entities.user fuser;
        public book() {}
        public book(BookModel value)
        {
            name = value.name;
            author = value.author;
            sumPages = value.sumPages;
            tags = JsonConvert.SerializeObject(value.tags);
            averageRating = value.averageRating;
            URLcover = value.urlCover;
            URLDescription = value.urlDescription;
            user = value.user;
        }

        public static implicit operator BookModel(book value)
        {
            return new BookModel(value);
        }

        //public virtual BookLibrary.Domain.Entities.DetailArrayOfReports reports
        //{
        //    get
        //    {
        //        if ((this.freport == null))
        //        {
        //            this.freport = new BookLibrary.Domain.Entities.DetailArrayOfReports(this);
        //        }
        //        BookLibrary.Domain.Entities.DetailArrayOfReports result = this.freport;
        //        return result;
        //    }
        //    set
        //    {
        //        this.freport = value;
        //    }
        //}


        [PropertyStorage(new string[] {"user_m0"})]
        [NotNull()]
        public virtual BookLibrary.Domain.Entities.user user
        {
            get
            {
                BookLibrary.Domain.Entities.user result = this.fuser;
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
                    return ICSSoft.STORMNET.Information.GetView("bookL", typeof(BookLibrary.Domain.Entities.book));
                }
            }
        }
    }
    //public class DetailArrayOfBooks : ICSSoft.STORMNET.DetailArray
    //{
    //    public DetailArrayOfBooks(BookLibrary.Domain.Entities.user fuser) :
    //            base(typeof(book), ((ICSSoft.STORMNET.DataObject)(fuser)))
    //    {
    //    }

    //    public BookLibrary.Domain.Entities.book this[int index]
    //    {
    //        get
    //        {
    //            return ((BookLibrary.Domain.Entities.book)(this.ItemByIndex(index)));
    //        }
    //    }

    //    public virtual void Add(BookLibrary.Domain.Entities.book dataobject)
    //    {
    //        this.AddObject(((ICSSoft.STORMNET.DataObject)(dataobject)));
    //    }

    //}
}
