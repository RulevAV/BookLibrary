using ICSSoft.STORMNET;
using System;

namespace BookLibrary.Entities
{
    [View("errorL", new string[] { "dateEerror" })]
    public class error : ICSSoft.STORMNET.DataObject
    {
        public string url { get; set; }
        public string message { get; set; }
        public string ipClient { get; set; }
        public DateTime dateEerror { get; set; }

        public void SetProperties(error _error)
        {
            this.url = _error.url;
            this.message = _error.message;
            this.ipClient = _error.ipClient;
            this.dateEerror = _error.dateEerror;
        }

        public class Views
        {
            /// <summary>
            /// "bookL" view.
            /// </summary>
            public static ICSSoft.STORMNET.View errorL
            {
                get
                {
                    return ICSSoft.STORMNET.Information.GetView("errorL", typeof(BookLibrary.Entities.error));
                }
            }
        }

        
    }
}
