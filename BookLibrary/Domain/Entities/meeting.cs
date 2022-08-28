using ICSSoft.STORMNET;
using System;

namespace BookLibrary.Domain.Entities
{
    [View("meetingL", new string[] { "dateMeeting"})]
    public class meeting : ICSSoft.STORMNET.DataObject
    {
        public DateTime dateMeeting { get; set; }

        //private BookLibrary.Domain.Entities.DetailArrayOfReports freport;

        public void SetProperties(meeting _meeting)
        {
            this.dateMeeting = _meeting.dateMeeting;
        }
        public report[] reports { get; set; }

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
            public static ICSSoft.STORMNET.View meetingL
            {
                get
                {
                    return ICSSoft.STORMNET.Information.GetView("meetingL", typeof(BookLibrary.Domain.Entities.meeting));
                }
            }
        }


    }
}
