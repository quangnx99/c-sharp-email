namespace CSharpEmail.Models
{
    using System;

    public class TmplBase : HtmlTempleteBase
    {
        protected TmplBase(string tmplName)
        {
            _tmplName = tmplName;
        }

        public override string Path => $"{AppDomain.CurrentDomain.BaseDirectory}Templates\\";
    }
}
