namespace CSharpEmail.Models
{
    public abstract class HtmlTempleteBase : IHtmlTemplete
    {
        public abstract string Path { get; }

        protected string _tmplName;

        public virtual string TmplName => $"{Path}{_tmplName}.html";
    }
}
