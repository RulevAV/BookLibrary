using ICSSoft.STORMNET;
using System;

namespace BookLibrary.Entities
{
    [View("meetingL", new string[] { "dateMeeting"})]
    public class meeting : ICSSoft.STORMNET.DataObject
    {
        public DateTime dateMeeting { get; set; }

        private BookLibrary.Entities.DetailArrayOfReports freport;

        public void SetProperties(meeting _meeting)
        {
            this.dateMeeting = _meeting.dateMeeting;
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

        public class Views
        {
            /// <summary>
            /// "bookL" view.
            /// </summary>
            public static ICSSoft.STORMNET.View meetingL
            {
                get
                {
                    return ICSSoft.STORMNET.Information.GetView("meetingL", typeof(BookLibrary.Entities.meeting));
                }
            }
        }


    }
}
