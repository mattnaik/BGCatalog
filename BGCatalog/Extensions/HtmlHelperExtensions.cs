using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BGCatalog.Web.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static string ByteArrayToImgTag(this IHtmlHelper html, byte[] RawImage)
        {
            var base64 = Convert.ToBase64String(RawImage);
            var imgSrc = String.Format("data:image/gif;base64,{0}", base64);
            return string.Format("<img src=\"{0}\" style=\"max-width: 75px; max-height:75px; \" />", imgSrc);
            
        }
    }
}
