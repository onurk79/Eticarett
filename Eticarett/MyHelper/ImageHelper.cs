using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eticarett.MyHelper
{
    public static class ImageHelper
    {
        public static IHtmlString Image(this HtmlHelper h,String src,int width 
            ,int height,string alt,string title)
        {
            string value = Image(src, width, height, alt, title);
            return new HtmlString(value);
        }
        public static IHtmlString Image(this HtmlHelper h, String src, int width
            , int height, string alt)
        {
            string value = Image(src, width, height, alt,string.Empty);
            return new HtmlString(value);
        }
        public static IHtmlString Image(this HtmlHelper h, String src, int width
          , int height)
        {
            string value = Image(src, width, height,string.Empty , string.Empty);
            return new HtmlString(value);
        }
        private static string Image(string src,
                                int width,
                                int height,
                                string alt,
                                string title)
        {
            TagBuilder builder = new TagBuilder("img");
            builder.Attributes.Add("src", src);
            builder.Attributes.Add("width", width.ToString());
            builder.Attributes.Add("height", height.ToString());
            builder.Attributes.Add("alt", alt);
            builder.Attributes.Add("title", title);
            return builder.ToString();
        }
    }
}