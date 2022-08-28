using ICSSoft.STORMNET;

namespace BookLibrary.Domain.Entities
{
    [View("speakerL", new string[] { "firstName", "lastName", "patronymic", /*"primarykey as \'id\'"*/ })]
    public class speaker : ICSSoft.STORMNET.DataObject
    {
        //public string id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string patronymic { get; set; }

        //private BookLibrary.Domain.Entities.DetailArrayOfReports freport;

        public void SetProperties(speaker _speaker)
        {
            this.firstName = _speaker.firstName;
            this.lastName = _speaker.lastName;
            this.patronymic = _speaker.patronymic;
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

        public class Views
        {
            /// <summary>
            /// "bookL" view.
            /// </summary>
            public static ICSSoft.STORMNET.View speakerL
            {
                get
                {
                    return ICSSoft.STORMNET.Information.GetView("speakerL", typeof(BookLibrary.Domain.Entities.speaker));
                }
            }
        }
    }
}
