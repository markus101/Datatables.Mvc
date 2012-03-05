using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace DataTables.Mvc.Core
{
    public static class GridHtmlHelper
    {
        public static MvcHtmlString GridHtml(this HtmlHelper html, string htmlId, string htmlClass)
        {
            var tableRow = String.Format("<table id=\"{0}\" class=\"{1}\">", htmlId, htmlClass);
            var sb = new StringBuilder();
            sb.AppendLine(tableRow);
            sb.AppendLine("<thead></thead>");
            sb.AppendLine("<tbody></tbody>");
            sb.AppendLine("</table>");

            return new MvcHtmlString(sb.ToString());
        }

        public static MvcHtmlString GridHtml(this HtmlHelper html, string htmlId)
        {
            var tableRow = String.Format("<table id=\"{0}\">", htmlId);
            var sb = new StringBuilder();
            sb.AppendLine(tableRow);
            sb.AppendLine("<thead></thead>");
            sb.AppendLine("<tbody></tbody>");
            sb.AppendLine("</table>");

            return new MvcHtmlString(sb.ToString());
        }

        public static Grid GridScript(this HtmlHelper html, string selector)
        {
            return new Grid(selector);
        }

        public static Grid GridScriptForModel(this HtmlHelper html, string selector)
        {
            var model = html.ViewData.Model;

            if (model == null)
                throw new ArgumentException("Model is invalid");

            return new Grid(selector).AData(JsonConvert.SerializeObject(model));
        }
    }
}
