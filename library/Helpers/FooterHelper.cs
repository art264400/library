using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace library.Helpers
{
    public static class FooterHelper
    {
        public static MvcHtmlString Footer(this HtmlHelper htmlHelper,params string[] items)
        {
            //< footer >< p > content </ p ></ footer >
            var footer=new TagBuilder("ul");
            foreach (var item in items)
            {
                var p=new TagBuilder("li");
                p.SetInnerText(item);
                footer.InnerHtml += p.ToString();
            }
            return new MvcHtmlString(footer.ToString());
        }
    }
}