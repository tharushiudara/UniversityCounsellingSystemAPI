using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Tls;

namespace UniversityCounsellingSystemAPI.Models.Entities
{
    [Keyless]
    public abstract class User
    {
        public string email;
        protected string name;
        private string contact_No;
       

        public string Contact_No
        {
            get => contact_No;
            set
            {
                if (value.Length == 10)
                {
                    contact_No = value;
                }
                else
                {
                    throw new ArgumentException("Please provide valid contact no");
                }
            }
        }


        protected string Email { get => email; set => email = value.Length>0? value: "default email"; }
        protected string Name { get => name; set => name = value.Length> 0? value: "default name"; }


        public User(string email)
        {
        }

        public User(string email, string name) : this(email)
        {
            Name = name;
        }

        public User(string contact_No, string email, string name) : this(contact_No, email)
        {
            Name = name;
        }


    }
}
