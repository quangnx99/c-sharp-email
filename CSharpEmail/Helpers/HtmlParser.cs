namespace CSharpEmail
{
    using System;
    using System.IO;

    public static class HtmlParser
    {

        public static string GenerateBody<TModel>(TModel body) where TModel : class
        {
            string tmplPath = $"{AppDomain.CurrentDomain.BaseDirectory}Templates\\{typeof(TModel).Name}.html";

            if (File.Exists(tmplPath))
            {
                var content = File.ReadAllText(tmplPath);

                var properties = body.GetType()
                    .GetProperties();

                foreach (var prop in properties)
                {
                    var val = GetPropValue(body, prop.Name);

                    content = content.Replace($"[{prop.Name}]", val);
                }

                return content;

            }

            throw new Exception($"Not found {tmplPath}");
        }

        private static string GetPropValue(object src, string propName)
        {
            return (string)src.GetType().GetProperty(propName).GetValue(src, null);
        }
    }
}
