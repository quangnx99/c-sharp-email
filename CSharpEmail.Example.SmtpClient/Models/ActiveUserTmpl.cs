namespace CSharpEmail.Example.SmtpClient.Models
{
    using CSharpEmail.Models;

    public class ActiveUserTmpl : TmplBase
    {
        public ActiveUserTmpl(string username, string displayName,
            string phoneNumber, string address) : this(typeof(ActiveUserTmpl).Name)
        {
            UserName = username;
            DisplayName = displayName;
            PhoneNumber = phoneNumber;
            Address = address;
        }

        protected ActiveUserTmpl(string tmplName) : base(tmplName)
        {
        }

        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
