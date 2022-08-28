using ICSSoft.STORMNET;

namespace BookLibrary.Domain.Entities
{
    [View("imageL", new string[] { "img" })]
    public class image : ICSSoft.STORMNET.DataObject
    {
        public string img { get; set; }
        public string type { get; set; }

        public class Views
        {
            /// <summary>
            /// "bookL" view.
            /// </summary>
            public static ICSSoft.STORMNET.View imageL
            {
                get
                {
                    return ICSSoft.STORMNET.Information.GetView("imageL", typeof(BookLibrary.Domain.Entities.image));
                }
            }
        }
    }
}
