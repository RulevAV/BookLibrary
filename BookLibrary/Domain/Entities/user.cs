using ICSSoft.STORMNET;

namespace BookLibrary.Domain.Entities
{
    [View("userL", new string[] { "email", "username", "password" })]
    public class user : ICSSoft.STORMNET.DataObject
    {
        public string email { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        private BookLibrary.Domain.Entities.DetailArrayOfBooks fbooks;
        public void SetProperties(user _user)
        {
            this.email = _user.email;
            this.username = _user.username;
            this.password = _user.password;
        }

        public class Views
        {
            /// <summary>
            /// "bookL" view.
            /// </summary>
            public static ICSSoft.STORMNET.View userL
            {
                get
                {
                    return ICSSoft.STORMNET.Information.GetView("userL", typeof(BookLibrary.Domain.Entities.user));
                }
            }
        }

        public virtual BookLibrary.Domain.Entities.DetailArrayOfBooks books
        {
            get
            {
                if ((this.fbooks == null))
                {
                    this.fbooks = new BookLibrary.Domain.Entities.DetailArrayOfBooks(this);
                }
                BookLibrary.Domain.Entities.DetailArrayOfBooks result = this.fbooks;
                return result;
            }
            set
            {
                this.fbooks = value;
            }
        }
    }
}
